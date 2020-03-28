﻿using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Utilities;

namespace EddiInaraService
{
    public partial class InaraService : IInaraService, INotifyPropertyChanged
    {
        // API Documentation: https://inara.cz/inara-api-docs/

        // Constants
        private const string readonlyAPIkey = "9efrgisivgw8kksoosowo48kwkkw04skwcgo840";
        private const int syncIntervalMilliSeconds = 60 * 5 * 1000; // 5 minutes
        private const int delayedSyncIntervalMilliSeconds = syncIntervalMilliSeconds * 12; // 60 minutes

        // Configuration Variables
        public string commanderName { get; private set; }
        public string commanderFrontierID { get; private set; }
        protected string apiKey
        {
            get 
            { 
                return _apiKey; 
            }
            private set 
            {
                _apiKey = value;
                NotifyPropertyChanged("apiKey");
            }
        }
        private string _apiKey;
        public DateTime lastSync { get; private set; }

        // Other Variables
        private bool tooManyRequests;
        private static bool bgSyncRunning; // This must be static so that it is visible to child threads and tasks
        public bool IsAPIkeyValid 
        {
            get
            {
                return _isAPIkeyValid;
            }
            private set
            {
                _isAPIkeyValid = value;
                NotifyPropertyChanged("IsAPIkeyValid");
            }
        }
        private bool _isAPIkeyValid = true;
        private static ConcurrentQueue<InaraAPIEvent> queuedAPIEvents { get; set; } = new ConcurrentQueue<InaraAPIEvent>();
        private readonly List<string> invalidAPIEvents = new List<string>();
        private static bool eddiInBeta;
        private static bool gameInBeta;

        // Methods
        public void Start(bool gameIsBeta = false, bool eddiIsBeta = false)
        {
            Logging.Debug("Starting Inara service background sync.");

            // Set up the Inara service credentials
            SetInaraCredentials();

            eddiInBeta = eddiIsBeta;
            gameInBeta = gameIsBeta;
            Task.Run(BackgroundSync);
        }

        public void Stop()
        {
            Logging.Debug("Stopping Inara service background sync.");
            bgSyncRunning = false;
        }

        private async void BackgroundSync()
        {
            bgSyncRunning = true;
            while (bgSyncRunning)
            {
                if (queuedAPIEvents.Count > 0 && IsAPIkeyValid)
                {
                    try
                    {
                        SendQueuedAPIEvents();
                    }
                    catch (InaraException e)
                    {
                        if (e is InaraAuthenticationException)
                        {
                            // The Inara API key has been rejected. We'll note and remember that.
                            IsAPIkeyValid = false;
                            InaraConfiguration inaraConfiguration = InaraConfiguration.FromFile();
                            inaraConfiguration.isAPIkeyValid = false;
                            inaraConfiguration.ToFile();
                        }
                        if (e is InaraTooManyRequestsException)
                        {
                            tooManyRequests = true;
                        }
                    }
                    await Task.Delay(!tooManyRequests ? syncIntervalMilliSeconds : delayedSyncIntervalMilliSeconds);
                    tooManyRequests = false;
                }
            }
        }

        private void SetInaraCredentials()
        {
            InaraConfiguration inaraCredentials = InaraConfiguration.FromFile();
            if (inaraCredentials == null) { return; }

            // commanderName: In-game CMDR name of user (not set by user, get this from journals or 
            // cAPI to ensure it is a correct in-game name to avoid future problems). It is recommended 
            // to be always set when no generic API key is used (otherwise some events may not work).
            commanderName = inaraCredentials.commanderName;

            // commanderFrontierID: Commander's unique Frontier ID (is provided by journals since 3.3)
            // in the format: 'F123456'. When not known, set nothing.
            commanderFrontierID = inaraCredentials.commanderFrontierID;

            lastSync = inaraCredentials.lastSync;
            apiKey = inaraCredentials.apiKey;
            IsAPIkeyValid = inaraCredentials.isAPIkeyValid;
            if (!string.IsNullOrEmpty(apiKey) && !string.IsNullOrEmpty(commanderName) && IsAPIkeyValid)
            {
                // fully configured
                Logging.Info("Configuring EDDI access to Inara profile data");
            }
            else
            {
                if (string.IsNullOrEmpty(apiKey))
                {
                    Logging.Info("Configuring Inara service for limited access: API key not set.");
                }
                if (!IsAPIkeyValid)
                {
                    Logging.Info("Configuring Inara service for limited access: API key is invalid.");
                }
                if (string.IsNullOrEmpty(commanderName))
                {
                    Logging.Info("Configuring Inara service for limited access: Commander name not detected.");
                }
                apiKey = readonlyAPIkey;
            }
        }

        // If you need to do some testing on Inara's API, please set the `isDeveloped` boolean header property to true.
        public List<InaraResponse> SendEventBatch(ref List<InaraAPIEvent> events, bool sendEvenForBetaGame = false)
        {
            if (!sendEvenForBetaGame && gameInBeta) { return null; }

            List<InaraResponse> inaraResponses = new List<InaraResponse>();

            if (string.IsNullOrEmpty(apiKey))
            {
                return inaraResponses;
            }

            // Flag each event with a unique ID we can use when processing responses
            List<InaraAPIEvent> indexedEvents = new List<InaraAPIEvent>();
            for (int i = 0; i < events.Count; i++)
            {
                InaraAPIEvent indexedEvent = events[i];
                indexedEvent.eventCustomID = i;
                if (!invalidAPIEvents.Contains(indexedEvent.eventName))
                {
                    // Add events, excluding events with issues that have returned a code 400 error in this instance.
                    indexedEvents.Add(indexedEvent);
                }
            }

            var client = new RestClient("https://inara.cz/inapi/v1/");
            var request = new RestRequest(Method.POST);
            InaraSendJson inaraRequest = new InaraSendJson()
            {
                header = new Dictionary<string, object>()
                {
                    // Per private conversation with Artie and per Inara API docs, the `isDeveloped` property
                    // should (counterintuitively) be set to true when the an application is in development.
                    // Quote: `it's "true" because the app "is (being) developed"`
                    // Quote: `isDeveloped is meant as "the app is currently being developed and may be broken`
                    { "appName", "EDDI" },
                    { "appVersion", Constants.EDDI_VERSION.ToString() },
                    { "isDeveloped", eddiInBeta },
                    { "commanderName", commanderName ?? (eddiInBeta ? "TestCmdr" : null) },
                    { "commanderFrontierID", commanderFrontierID },
                    { "APIkey", apiKey }
                },
                events = indexedEvents
            };
            request.RequestFormat = DataFormat.Json;
            request.AddBody(inaraRequest); // uses JsonSerializer

            Logging.Debug("Sending to Inara: " + client.BuildUri(request).AbsoluteUri);
            var clientResponse = client.Execute<InaraResponses>(request);
            if (clientResponse.IsSuccessful)
            {
                InaraResponses response = clientResponse.Data;
                if (validateResponse(response.header, ref indexedEvents, true))
                {
                    foreach (InaraResponse inaraResponse in response.events)
                    {
                        if (validateResponse(inaraResponse, ref indexedEvents))
                        {
                            inaraResponses.Add(inaraResponse);
                        }
                    }
                }
                return inaraResponses;
            }
            else
            {
                Logging.Warn("Unable to connect to the Inara server.", clientResponse.ErrorMessage);
                foreach (InaraAPIEvent inaraAPIEvent in events)
                {
                    // Re-enqueue and send at a later time.
                    EnqueueAPIEvent(inaraAPIEvent);
                }
                return null;
            }
        }

        private bool validateResponse(InaraResponse inaraResponse, ref List<InaraAPIEvent> indexedEvents, bool header = false)
        {
            if (inaraResponse.eventStatus == 200)
            {
                // 200 - Ok
                return true;
            }
            else
            {
                Dictionary<string, object> data = new Dictionary<string, object>()
                {
                    { "InaraAPIEvent", indexedEvents.Find(e => e.eventCustomID == inaraResponse.eventCustomID) },
                    { "InaraResponse", inaraResponse }
                };
                if (inaraResponse.eventStatus == 400)
                {
                    // 400 - Error (you probably did something wrong, there are properties missing, etc. The event was skipped or whole batch cancelled on failed authorization.)
                    Logging.Error("Inara responded with: " + inaraResponse.eventStatusText, JsonConvert.SerializeObject(data));

                    if (!string.IsNullOrEmpty(inaraResponse.eventStatusText))
                    {
                        if (inaraResponse.eventStatusText.Contains("Invalid API key"))
                        {
                            throw new InaraAuthenticationException(inaraResponse.eventStatusText);
                        }
                        else if (inaraResponse.eventStatusText.Contains("access to API was temporarily revoked"))
                        {
                            throw new InaraTooManyRequestsException(inaraResponse.eventStatusText);
                        }
                        else
                        {
                            // There may be an issue with a specific API event.
                            // We'll add that API event to a list and omit sending that event again in this instance.
                            invalidAPIEvents.Add(indexedEvents.Find(e => e.eventCustomID == inaraResponse.eventCustomID).eventName);
                            throw new InaraErrorException(inaraResponse.eventStatusText);
                        }
                    }
                }
                else
                {
                    // 202 - Warning (everything is OK, but there may be multiple results for the input properties, etc.)
                    // 204 - 'Soft' error (everything was formally OK, but there are no results for the properties set, etc.)
                    // Inara may also return null as it undergoes a nightly manintenance cycle where the servers go offline temporarily.
                    Logging.Warn("Inara responded with: " + (inaraResponse.eventStatusText ?? "(No response)"), JsonConvert.SerializeObject(data));
                }
                return false;
            }
        }

        public void SendQueuedAPIEvents()
        {
            List<InaraAPIEvent> queue = new List<InaraAPIEvent>();
            while (queuedAPIEvents.TryDequeue(out InaraAPIEvent pendingEvent))
            {
                queue.Add(pendingEvent);
            }
            if (queue.Count > 0)
            {
                if (SendEventBatch(ref queue).Count > 0)
                {
                    lastSync = queue.Max(e => e.eventTimeStamp);
                    InaraConfiguration inaraConfiguration = InaraConfiguration.FromFile();
                    inaraConfiguration.lastSync = lastSync;
                    inaraConfiguration.ToFile();
                }
            }
        }

        public void EnqueueAPIEvent(InaraAPIEvent inaraAPIEvent)
        {
            if (!(inaraAPIEvent is null) && lastSync < inaraAPIEvent.eventTimeStamp)
            {
                queuedAPIEvents.Enqueue(inaraAPIEvent);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }

    internal class InaraSendJson
    {
        public Dictionary<string, object> header { get; set; }

        public List<InaraAPIEvent> events { get; set; }
    }

    internal class InaraResponses
    {
        public InaraResponse header { get; set; }

        public List<InaraResponse> events { get; set; }
    }

    public class InaraResponse
    {
        public int eventStatus { get; set; }

        public string eventStatusText { get; set; }

        public object eventData { get; set; }

        public int eventCustomID { get; set; } // Optional index
    }
}

﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace EddiDataDefinitions
{
    public class Mission : INotifyPropertyChanged
    {
        // The mission ID
        public long missionid { get; private set; }

        // The name of the mission
        public string name { get; set; }

        // The localised name of the mission
        public string localisedname;

        // The type of mission
        public string typeEDName
        {
            get => typeDef.edname;
            set
            {
                MissionType tDef = MissionType.FromEDName(value);
                this.typeDef = tDef;
            }
        }

        [JsonIgnore]
        private MissionType _typeDef;
        [JsonIgnore]
        public MissionType typeDef
        {
            get => _typeDef;
            set
            {
                _typeDef = value;
                NotifyPropertyChanged("localizedType");
            }
        }

        [JsonIgnore]
        public string localizedType => typeDef?.localizedName ?? "Unknown";
        [JsonIgnore, Obsolete("Please use localizedName or invariantName")]
        public string type => localizedType;

        // Status of the mission
        public string statusEDName
        {
            get => statusDef.edname;
            set
            {
                MissionStatus sDef = MissionStatus.FromEDName(value);
                this.statusDef = sDef;
            }
        }

        [JsonIgnore]
        private MissionStatus _statusDef;
        [JsonIgnore]
        public MissionStatus statusDef
        {
            get => _statusDef;
            set
            {
                _statusDef = value;
                NotifyPropertyChanged("localizedStatus");
            }
        }

        [JsonIgnore]
        public string localizedStatus => statusDef?.localizedName ?? "Unknown";
        [JsonIgnore, Obsolete("Please use localizedName or invariantName")]
        public string status => localizedStatus;

        // The system in which the mission was accepted
        public string originsystem { get; set; }

		// The station in which the mission was accepted
        public string originstation { get; set; }

        // Mission returns to origin
        public bool originreturn { get; set; }

        public string faction { get; set; }
        public string factionstate { get; set; }

        public string influence { get; set; }
        public string reputation { get; set; }

        public bool chained => name.ToLowerInvariant().Contains("chained");
        public bool communal { get; set; }
        public bool legal => !name.ToLowerInvariant().Contains("illegal") && !name.ToLowerInvariant().Contains("smuggle");
        public bool shared { get; set; }
        public bool wing { get; set; }

        public long? reward { get; set; }

        public string commodity { get; set; }
        public int? amount { get; set; }

		// THe destination system of the mission
        private string _destinationsystem;
		public string destinationsystem
        {
            get
            {
                return _destinationsystem;
            }
            set
            {
                if (_destinationsystem != value)
                {
                    _destinationsystem = value;
                    NotifyPropertyChanged("destinationsystem");
                }
            }
        }

		// The destination station of the mission
        private string _destinationstation;
		public string destinationstation
        {
            get
            {
                return _destinationstation;
            }
            set
            {
                if (_destinationstation != value)
                {
                    _destinationstation = value;
                    NotifyPropertyChanged("destinationstation");
                }
            }
        }
        // Desintation systems for chained missions
        public List<DestinationSystem> destinationsystems { get; set; }

        // The mission time remaining
        [JsonIgnore]
        private string _timeremaining;
        [JsonIgnore]
        public string timeremaining
        {
            get
            {
                return _timeremaining;
            }
            set
            {
                if (_timeremaining != value)
                {
                    _timeremaining = value;
                    NotifyPropertyChanged("timeremaining");
                }
            }
        }

        public string passengertypeEDName { get; set; }
        [JsonIgnore]
        public string passengertype => PassengerType.FromEDName(passengertypeEDName)?.localizedName;
        public bool? passengerwanted { get; set; }
        public bool? passengervips { get; set; }

        public string target { get; set; }
        public string targetfaction { get; set; }
        public string targetTypeEDName;
        [JsonIgnore]
        public string targettype => TargetType.FromEDName(targetTypeEDName)?.localizedName;

        public DateTime? expiry { get; set; }
        [JsonIgnore]
        public long? expiryseconds => (long)expiry?.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

        // Default Constructor
        public Mission() { }

        [JsonConstructor]
        // Main Constructor
        public Mission(long MissionId, string Name, DateTime? expiry, MissionStatus Status, bool Shared = false)
		{
			this.missionid = MissionId;
			this. name = Name;
			this.expiry = expiry?.ToUniversalTime();
            this.statusDef = Status;
            this.shared = Shared;
            destinationsystems = new List<DestinationSystem>();

            // Mechanism for identifying chained, 'welcome', and 'special' missions
            string type = Name.Split('_').ElementAt(1)?.ToLowerInvariant();
            switch (type)
            {
                case "drawthegeneralout":
                case "findthepiratelord":
                case "rampantleadership":
                case "regainfooting":
                case "salvagejustice":
                case "seekingasylum":
                case "wrongtarget":
                    {
                        this.typeDef = MissionType.FromEDName("Assassinate");
                    }
                    break;
                case "clearingthepath":
                case "helpfinishtheorder":
                    {
                        this.typeDef = MissionType.FromEDName("Deliver");
                    }
                    break;
                case "helpwithpreventionmeasures":
                    {
                        this.typeDef = MissionType.FromEDName("Massacre");
                    }
                    break;
                case "miningtoorder":
                    {
                        this.typeDef = MissionType.FromEDName("Mining");
                    }
                    break;
                case "safetravelling":
                case "securingmyposition":
                    {
                        this.typeDef = MissionType.FromEDName("PassengerVIP");
                    }
                    break;
                case "rescuefromthetwins":
                case "rescuethewares":
                    {
                        this.typeDef = MissionType.FromEDName("Salvage");
                    }
                    break;
                case "planetaryincursions":
                    {
                        this.typeDef = MissionType.FromEDName("Scan");
                    }
                    break;
                case "thedead":
                    {
                        this.typeDef = MissionType.FromEDName("Special");
                    }
                    break;
                case "ds":
                case "rs":
                case "welcome":
                    {
                        type = Name.Split('_').ElementAt(2)?.ToLowerInvariant();
                        this.typeDef = MissionType.FromEDName(type);
                    }
                    break;
                default:
                    {
                        this.typeDef = MissionType.FromEDName(type);
                    }
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}

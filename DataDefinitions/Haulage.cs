﻿using Newtonsoft.Json;
using System;
using System.Linq;

namespace EddiDataDefinitions
{
    public class Haulage
    {
        public long missionid { get; private set; }

        public string name { get; private set; }

        public string typeEDName { get; private set; }

        [JsonIgnore, Obsolete("Please use localizedName or invariantName")]
        public string type => MissionType.FromEDName(typeEDName)?.localizedName;

        public string status { get; set; }

        public string originsystem { get; set; }

        [JsonIgnore]
        public bool legal => !name.ToLowerInvariant().Contains("illegal");

        [JsonIgnore]
        public bool wing => name.ToLowerInvariant().Contains("wing");

        public int amount { get; private set; }

        public int remaining { get; set; }

        public long startmarketid { get; set; }

        public long endmarketid { get; set; }

        public int collected { get; set; }

        public int delivered { get; set; }

        public DateTime? expiry { get; set; }

        public bool shared { get; private set; }

        public Haulage() { }

        public Haulage(Haulage haulage)
        {
            missionid = haulage.missionid;
            name = haulage.name;
            typeEDName = haulage.typeEDName;
            originsystem = haulage.originsystem;
            status = haulage.status;
            amount = haulage.amount;
            startmarketid = haulage.startmarketid;
            endmarketid = haulage.endmarketid;
            remaining = haulage.remaining;
            collected = haulage.collected;
            delivered = haulage.delivered;
            expiry = haulage.expiry;
            shared = haulage.shared;
        }

        public Haulage(long MissionId, string Name, string OriginSystem, int Amount, DateTime? Expiry, bool Shared = false)
        {
            missionid = MissionId;
            name = Name;
            originsystem = OriginSystem;
            status = "Active";
            amount = Amount;
            remaining = Amount;
            expiry = Expiry;
            shared = Shared;

            // Mechanism for identifying chained delivery and 'welcome' missions
            typeEDName = Name.Split('_').ElementAtOrDefault(1)?.ToLowerInvariant();
            switch (typeEDName)
            {
                case "clearingthepath":
                case "helpfinishtheorder":
                    {
                        typeEDName = "delivery";
                    }
                    break;
                case "ds":
                case "rs":
                case "welcome":
                    {
                        typeEDName = Name.Split('_').ElementAt(2)?.ToLowerInvariant();
                    }
                    break;
            }
        }
    }
}

﻿namespace EddiDataDefinitions
{
    public class DestinationSystem
    {
        public string name { get; set; }

        public bool visited;

        public DestinationSystem() { }

        public DestinationSystem(DestinationSystem DestinationSystem)
        {
            this.name = DestinationSystem.name;
        }

        public DestinationSystem(string Name)
        {
            this.name = Name;
            this.visited = false;
        }
    }
}

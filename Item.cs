using System.Collections.Generic;

namespace ProjectDover
{
    public class Item
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool HasSeenDescription { get; set; }

        public Dictionary<string,string> Triggers {get; set;}
        
        //TODO: add states
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDover
{
    public class Item
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool HasSeenDescription { get; set; }

        //TODO: add states
    }
}

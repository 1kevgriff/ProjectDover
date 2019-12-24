using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectDover
{
    public class Inventory
    {
        public string Name { get; set; }
        public List<Item> Items { get; set; }

        public Inventory(){
            Name = "RoomItems";
            Items = new List<Item>();
        }

        public Inventory(string name){
            Name = name;
            Items = new List<Item>();
        }

        public Item RemoveItem(string itemName)
        {
            Item item = Items.First(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            return RemoveItem(item);
        }

        public Item RemoveItem(Item item)
        {
            Items.Remove(item);
            Console.WriteLine($"The {item.Name} was removed from {Name}.");
            return item;
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
            Console.WriteLine($"The {item.Name} was added to {Name}.");
        }

        public void ListItems()
        {
            StringBuilder itemlist = new StringBuilder();

            foreach (Item i in Items) {
                itemlist.Append(i.Name + ", ");
            }

            if (itemlist.Length > 0)
            {
                itemlist.Remove(itemlist.Length - 2, 2);
                Console.WriteLine($"{Name} contains {itemlist.ToString()}.");
            }
            else {
                Console.WriteLine($"{Name} is empty.");
            }
        }


        public void LookAt(string itemName)
        {
            var result = (from item in Items
                          where item.Name.ToLower() == itemName.ToLower()
                          select item).FirstOrDefault<Item>();

            if (result != null)
            {
                Console.WriteLine($"{result.Description}.");
            }
            else
            {
                Console.WriteLine($"The {itemName} was not found into {Name}.");
            }
        }

        public bool Contains(string itemName){
            return Items.Any(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
        }
    }


}

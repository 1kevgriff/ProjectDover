using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectDover
{
    public class Inventory
    {
        public string name { get; set; }
        public List<Item> Items { get; set; }

        public Item RemoveItem(Item item)
        {
            Items.Remove(item);
            Console.WriteLine($"The {item} was removed from {name}.");
            return item;
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
            Console.WriteLine($"The {item} was added to {name}.");
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
                Console.WriteLine($"{name} contains {itemlist.ToString()}.");
            }
            else {
                Console.WriteLine($"{name} is empty.");
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
                Console.WriteLine($"The {itemName} was not found into {name}.");
            }
        }
    }


}

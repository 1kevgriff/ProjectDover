using System;
using System.Linq;

namespace ProjectDover
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new CommandParser();
            var roomManager = new RoomManager();
            var inventory = new Inventory("Your Inventory");

            while (true)
            {
                // spit room desc
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(roomManager.CurrentRoomName);
                Console.ResetColor();
                if (!roomManager.CurrentRoomHasSeenDescription)
                {
                    Console.WriteLine(roomManager.CurrentRoomDescription);
                }

                Console.WriteLine(roomManager.CurrentRoomExits());
                Console.Write("> ");
                var inputString = Console.ReadLine();

                var command = parser.ProcessCommandText(inputString);
                switch (command)
                {
                    case Command.COMMAND_QUIT:
                        {
                            Console.Clear();
                            Console.WriteLine("Thanks for playing!");
                            Environment.Exit(0);
                        }
                        break;
                    case Command.COMMAND_NORTH:
                    case Command.COMMAND_SOUTH:
                    case Command.COMMAND_EAST:
                    case Command.COMMAND_WEST:
                    {
                        roomManager.Go(command);
                    }
                        break;
                    case Command.COMMAND_LOOK:
                        {
                            roomManager.Do(command);
                        }
                        break;
                    case Command.COMMAND_INVENTORY:
                        {
                            inventory.ListItems();
                        }
                        break;
                    case Command.COMMAND_TAKE:
                        {
                            Inventory roomInventory = roomManager.CurrentRoomInventory();
                            string itemName = inputString.Split(' ')[1];
                
                            if(roomInventory.Contains(itemName)){
                                Item currentItem = roomInventory.RemoveItem(itemName);

                                if(currentItem.Triggers.ContainsKey("take")){
                                    roomManager.ProcessTrigger(currentItem.Triggers["take"]);
                                }

                                inventory.AddItem(currentItem);
                            }
                        }
                        break;
                    case Command.COMMAND_HANDLED: break;
                    default:
                        {
                            Console.WriteLine();
                            Console.WriteLine("I'm not sure what to do");
                        }
                        break;
                }
            }
        }
    }
}

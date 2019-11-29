using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectDover
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new CommandParser();
            var GameSession = new GameSession();
           

            while (true)
            {
                // spit room desc
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(GameSession.RoomManager.CurrentRoomName);
                Console.ResetColor();
                if (!GameSession.RoomManager.CurrentRoomHasSeenDescription)
                {
                    Console.WriteLine(GameSession.RoomManager.CurrentRoomDescription);
                }

                Console.WriteLine(GameSession.RoomManager.CurrentRoomExits());
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
                        GameSession.RoomManager.Go(command);
                    }
                        break;
                    case Command.COMMAND_LOOK:
                        {
                            GameSession.RoomManager.Do(command);
                        }
                        break;
                    case Command.COMMAND_INVENTORY:
                        {
                            GameSession.Inventory.ListItems();
                        }
                        break;
                    case Command.COMMAND_TAKE:
                        {
                            Inventory roomInventory = GameSession.RoomManager.CurrentRoomInventory();
                            string itemName = inputString.Split(' ')[1];
                
                            if(roomInventory.Contains(itemName)){
                                Item currentItem = roomInventory.RemoveItem(itemName);

                                if(currentItem.Triggers.ContainsKey("take")){
                                    string keyEvent = GameSession.RoomManager.ProcessTrigger(currentItem,"take");
                                    if(!String.IsNullOrEmpty(keyEvent)){
                                        GameSession.KeyEvents.Add(keyEvent);
                                    }
                                }

                                GameSession.Inventory.AddItem(currentItem);
                            }
                        }
                        break;
                    case Command.COMMAND_SUMMARY:
                        {
                            Console.WriteLine(GameSession.Summary());
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

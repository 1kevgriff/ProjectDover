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
            var roomManager = new RoomManager();

            while (true)
            {
                // spit room desc
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(roomManager.GetCurrentRoomName());
                Console.ResetColor();
                Console.WriteLine(roomManager.GetCurrentRoomDescription());

                Console.WriteLine();
                Console.Write("> ");
                var inputString = Console.ReadLine();

                switch (parser.ProcessCommandText(inputString))
                {
                    case Command.COMMAND_QUIT:
                        {
                            Console.Clear();
                            Console.WriteLine("Thanks for playing!");
                            Environment.Exit(0);
                        }
                        break;

                    case Command.UNKNOWN:
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

    public class RoomManager
    {
        private List<Room> Rooms { get; set; }
        private long CurrentRoomId {get;set;}
        private Room CurrentRoom { get { return Rooms.First(p=>p.Id == CurrentRoomId);}}

        public RoomManager()
        {
            CurrentRoomId = 0;

            Rooms = new List<Room>();
            Rooms.Add(new Room()
            {
                Id = 0,
                Name = "Outside Brady's House",
                Description = "Brady has an extremely loved home.  There are even trees and flowers.  On your left, there is a truck up on some blocks.",
                Exits = new List<Exit>() { new Exit() { Direction = Direction.NORTH, TargetRoomId = 1 } }
            });
            Rooms.Add(new Room()
            {
                Id = 1,
                Name = "Inside Brady's House",
                Description = "The inside is even nicer than the outside.  $4000 of electronic equipment sit on a table.",
                Exits = new List<Exit>() { new Exit() { Direction = Direction.SOUTH, TargetRoomId = 0 } }
            });
        }

        public string GetCurrentRoomName(){
            return CurrentRoom.Name;
        }
        public string GetCurrentRoomDescription() {
            return CurrentRoom.Description;
        }
    }

    public class Room
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Exit> Exits { get; set; }
    }

    public class Exit
    {
        public Direction Direction { get; set; }
        public long TargetRoomId { get; set; }
    }

    public enum Direction
    {
        NORTH,
        SOUTH,
        EAST,
        WEST,
        UP,
        DOWN
    }
}

using System.Collections.Generic;
using System.Linq;

namespace ProjectDover
{
    public class RoomManager
    {
        private List<Room> Rooms { get; set; }
        private long CurrentRoomId { get; set; }
        private Room CurrentRoom { get { return Rooms.First(p => p.Id == CurrentRoomId); } }

        public RoomManager()
        {
            CurrentRoomId = 0;

            Rooms = new List<Room>();
            Rooms.Add(new Room()
            {
                Id = 0,
                Name = "Outside Brady's House",
                Description = "Brady has an extremely loved home.  There are even trees and flowers.  On your left, there is a truck up on some blocks.",
                Exits = new List<Exit>() { new Exit() { Direction = Direction.North, TargetRoomId = 1 } }
            });
            Rooms.Add(new Room()
            {
                Id = 1,
                Name = "Inside Brady's House",
                Description = "The inside is even nicer than the outside.  $4000 of electronic equipment sit on a table.",
                Exits = new List<Exit>() { new Exit() { Direction = Direction.South, TargetRoomId = 0 } }
            });
        }

        public string CurrentRoomName => CurrentRoom.Name;
        public string CurrentRoomDescription => CurrentRoom.Description;
        public string CurrentRoomExits()
        {
            var exitList = new List<string>();
            foreach (var currentRoomExit in CurrentRoom.Exits)
            {
                exitList.Add(Exit.GetDirection(currentRoomExit.Direction));
            }

            return $"Exits: {string.Join(", ", exitList)}";
        }
    }
}
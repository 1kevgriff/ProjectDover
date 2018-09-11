using System;

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
                Console.WriteLine(roomManager.CurrentRoomName);
                Console.ResetColor();
                Console.WriteLine(roomManager.CurrentRoomDescription);
                Console.WriteLine(roomManager.CurrentRoomExits());
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
}

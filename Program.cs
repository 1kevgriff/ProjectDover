using System;

namespace ProjectDover
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new CommandParser();
            while (true)
            {
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
                            Console.WriteLine("I'm not sure what to do");
                        }
                        break;
                }
            }
        }
    }

    public enum Command
    {
        UNKNOWN = -1,
        COMMAND_QUIT
    }
    public class CommandParser
    {
        public Command ProcessCommandText(string commandText)
        {
            if (commandText.Equals("QUIT", StringComparison.OrdinalIgnoreCase))
            {
                return Command.COMMAND_QUIT;
            }

            return Command.UNKNOWN;
        }
    }
}

using System;

namespace ProjectDover
{
    public class CommandParser
    {
        public Command ProcessCommandText(string commandText)
        {
            if (commandText.Equals("EXIT", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Did you mean `quit`?");
                return Command.COMMAND_HANDLED;
            }

            if (commandText.Equals("QUIT", StringComparison.OrdinalIgnoreCase))
            {
                return Command.COMMAND_QUIT;
            }

            if (commandText.Equals("LOOK", StringComparison.OrdinalIgnoreCase)
                || commandText.Equals("L", StringComparison.OrdinalIgnoreCase))
            {
                return Command.COMMAND_NORTH;
            }

            if (commandText.Equals("NORTH", StringComparison.OrdinalIgnoreCase) 
                || commandText.Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                return Command.COMMAND_NORTH;
            }
            if (commandText.Equals("SOUTH", StringComparison.OrdinalIgnoreCase)
                || commandText.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                return Command.COMMAND_SOUTH;
            }
            if (commandText.Equals("EAST", StringComparison.OrdinalIgnoreCase)
                || commandText.Equals("E", StringComparison.OrdinalIgnoreCase))
            {
                return Command.COMMAND_EAST;
            }
            if (commandText.Equals("WEST", StringComparison.OrdinalIgnoreCase)
                || commandText.Equals("W", StringComparison.OrdinalIgnoreCase))
            {
                return Command.COMMAND_WEST;
            }

            return Command.UNKNOWN;
        }
    }
}

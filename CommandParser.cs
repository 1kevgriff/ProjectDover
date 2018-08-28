using System;

namespace ProjectDover
{
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

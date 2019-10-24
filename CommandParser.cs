﻿using System;

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
                return Command.COMMAND_LOOK;
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
            if (commandText.Equals("INVENTORY", StringComparison.OrdinalIgnoreCase)
                || commandText.Equals("I", StringComparison.OrdinalIgnoreCase))
            {
                return Command.COMMAND_INVENTORY;
            }


            // == Interaction commands ====
            if(commandText.StartsWith("TAKE", StringComparison.OrdinalIgnoreCase)
                || commandText.Equals("T", StringComparison.OrdinalIgnoreCase)){

                if(commandText.Split(' ').Length > 1){
                    return Command.COMMAND_TAKE;
                }
                Console.WriteLine("What do you want to take?");
                return Command.COMMAND_HANDLED;
            }

            return Command.UNKNOWN;
        }
    }
}

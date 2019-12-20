

using System;

namespace ProjectDover
{
    public class GameTypeParser
    {
        public static GameType ProcessGameTypeText(string gameTypeText)
        {
            if (gameTypeText.Equals("NEW", StringComparison.OrdinalIgnoreCase)
                || gameTypeText.Equals("N", StringComparison.OrdinalIgnoreCase)
                || gameTypeText.Equals("1", StringComparison.OrdinalIgnoreCase))
            {
                return GameType.NEW_GAME;
            }

            if (gameTypeText.Equals("Load", StringComparison.OrdinalIgnoreCase)
                || gameTypeText.Equals("L", StringComparison.OrdinalIgnoreCase)
                || gameTypeText.Equals("2", StringComparison.OrdinalIgnoreCase))
            {
                return GameType.LOADED_GAME;
            }

            return GameType.UNKNOWN;
        }
    }
}
using System;
using GuessCore.Helpers;
using GuessCore.Interfaсes;

namespace GuessCore.Converters
{
    public class ToGameTypeConverter : IConverter<GameTypeKey>
    {
        public GameTypeKey Convert(string str)
        {
            switch (str)
            {
                case "Singleplayer": return GameTypeKey.Singleplayer;
                case "Multiplayer": return GameTypeKey.Multiplayer;
                default:
                    throw new Exception($"Тип игры {str} не найден.");
            }
        }
    }
}
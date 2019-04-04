using System;
using GuessCore.Helpers;
using GuessCore.Interfaсes;

namespace GuessCore.Converters
{
    public class ToLevelConverter : IConverter<LevelKey>
    {
        public LevelKey Convert(string str)
        {
            switch (str)
            {
                case "Easy":
                case "easy": return LevelKey.Easy;
                case "Medium":
                case "medium": return LevelKey.Medium;
                case "Hard":
                case "hard": return LevelKey.Hard;
                default:
                    throw new Exception($"Уровень {str} не найден.");
            }
        }
    }
}
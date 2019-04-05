using GuessConsole.GuessStuff;
using GuessConsole.Interfases;
using GuessCore.Converters;
using GuessCore.Facade;
using GuessCore.Helpers;
using GuessCore.Interfaсes;
using System;

namespace GuessConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            

            IConverter<GameTypeKey> gameTypeConverter = new ToGameTypeConverter();
            do
            {
                Console.WriteLine("Выберите тип игры (Singleplayer, Multiplayer):");
                var line = Console.ReadLine();
                try
                {
                    switch (gameTypeConverter.Convert(line))
                    {
                        case GameTypeKey.Singleplayer: (new SingleplayerGameStaff()).Run(); return;
                        case GameTypeKey.Multiplayer: (new MultiplayerGameStaff()).Run(); return;
                        default: return;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (true);

        }


    }
}

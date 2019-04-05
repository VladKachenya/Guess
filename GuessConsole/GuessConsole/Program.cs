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


            


            //while (!isBreak)
            //{
            //    Console.WriteLine("Ввидите уровень (Easy, Medium, Hard)");
            //    var nam = Console.ReadLine();
            //    isBreak = ConsoleHelper.GetResponse(guess[InteractorKey.RespondentAutoConfigure], nam);
            //}
            //Console.Clear();

            //isBreak = false;
            //var retryCounter = guess.GetRetryCounter();
            //isBreak = ConsoleHelper.GetResponse(guess[InteractorKey.Guess], "");
            //while (!isBreak)
            //{
            //    Console.WriteLine($"Оставшееся число попыток {retryCounter.Attempts}/{retryCounter.NumberOfAttempts}");
            //    Console.WriteLine("Введите число");
            //    var nam = Console.ReadLine();
            //    isBreak = ConsoleHelper.GetResponse(guess[InteractorKey.Guess], nam);
            //}
            //Console.Clear();
        }


    }
}

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
            IGuessFacade guess = new GuessFacade();
            guess.Initialize();
            bool isBreak = false;
            while (!isBreak)
            {
                Console.WriteLine("Ввидите уровень (Easy, Medium, Hard)");
                var nam = Console.ReadLine();
                isBreak = GetResponse(guess[InteractorKey.RespondentAutoConfigure], nam);
            }
            Console.Clear();

            isBreak = false;
            var retryCounter = guess.GetRetryCounter();
            isBreak = GetResponse(guess[InteractorKey.Guess], "");
            while (!isBreak)
            {
                Console.WriteLine($"Оставшееся число попыток {retryCounter.Attempts}/{retryCounter.NumberOfAttempts}");
                Console.WriteLine("Введите число");
                var nam = Console.ReadLine();
                isBreak = GetResponse(guess[InteractorKey.Guess], nam);
            }
            Console.Clear();
        }

        private static bool GetResponse(IInteractor interactor, string str)
        {
            var res = interactor.Interact(str);
            Console.WriteLine(res.Massage);
            return res.IsSuccessfulOperation;
        }
    }
}

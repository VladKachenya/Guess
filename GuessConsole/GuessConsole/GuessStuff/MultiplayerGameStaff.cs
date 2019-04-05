using GuessConsole.Helpre;
using GuessCore.Helpers;
using GuessCore.Interfaсes;
using System;
using GuessConsole.Interfases;

namespace GuessConsole.GuessStuff
{
    public class MultiplayerGameStaff : GameStaffBase, IGameStaff
    {

        public void Run()
        {
            char exitCh;
            do
            {
                Console.Clear();
                _Guess.Initialize();
                var isBreak = false;
                var interactor = _Guess[InteractorKey.RespondentManualConfigure];

                // Конфигурация
                ConsoleHelper.GetResponse(interactor, "");
                do
                {
                    var req = Console.ReadLine();
                    isBreak = ConsoleHelper.GetResponse(interactor, req);
                } while (!isBreak);
                Console.Clear();


                // Процесс игры
                interactor = _Guess[InteractorKey.Guess];
                IRetryCounter retryCounter = _Guess.GetRetryCounter();
                ConsoleHelper.GetResponse(interactor, "");
                do
                {
                    Console.WriteLine(
                        $"Израсходованное число попыток {retryCounter.Attempts}/{retryCounter.NumberOfAttempts}");
                    Console.WriteLine("Введите число:");
                    var req = Console.ReadLine();
                    isBreak = ConsoleHelper.GetResponse(interactor, req);
                    if (!isBreak && !retryCounter.IsAttemptsRemained)
                    {
                        isBreak = true;
                        Console.WriteLine("Вы проиграли.");
                    }
                } while (!isBreak);
                isBreak = false;

                //Продолжить или нет
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Хотите продолжить? y/n");
                    exitCh = Console.ReadKey().KeyChar;

                    if (exitCh == 'n' || exitCh == 'y')
                    {
                        isBreak = true;
                    }

                } while (!isBreak);
            } while (exitCh == 'y');
        }

    }
}
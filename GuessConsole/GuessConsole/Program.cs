using GuessCore.Factories;
using GuessCore.Helpers;
using GuessCore.Interactors;
using System;
using GuessCore.Facade;
using GuessCore.Interfaсes;
using GuessCore.Interfaсes.Facade;

namespace GuessConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IFacadeExternal guess = new GuessFacade(new RespondentFactory());
            guess.Initialize();
            bool isBreak = false;

            do
            {
                Console.WriteLine("Configyre respondent!");
                isBreak = GetResponse(guess[GuessCoreKeys.Interactors.RespondentConfigureInteractorKey]);
            } while (!isBreak);
            Console.Clear();

        }

        private static bool GetResponse(IInteractor interactor)
        {
            var nam = Console.ReadLine();
            var res = interactor.Interact(nam);
            res.MassageList.ForEach(el => Console.WriteLine(el));
            return res.IsSuccessfulOperation;
        }
    }
}

using GuessCore.Factories;
using GuessCore.Helpers;
using GuessCore.Interactors;
using System;
using GuessCore.Facade;
using GuessCore.Interfaсes.Facade;

namespace GuessConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IFacadeExternal guess = new GuessFacade(new RespondentFactory());
            guess.Initialize();
            var interactor = guess[GuessCoreKeys.Interactors.LoginInteractorKey];
            OperationResult res;
            do
            {
                Console.WriteLine("Enter namber!");
                var nam = Console.ReadLine();
                res = interactor.Interact(nam);
            } while (!res.IsSuccessfulOperation);


        }
    }
}

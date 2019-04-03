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
                Console.WriteLine("Enter min namber!");
                isBreak = GetResponse(guess[GuessCoreKeys.Interactors.GetMinNumbInteractorKey]);
            } while (!isBreak);
            Console.Clear();

            do
            {
                Console.WriteLine("Enter max namber!");
                isBreak = GetResponse(guess[GuessCoreKeys.Interactors.GetMaxNumbInteractorKey]);
            } while (!isBreak);
            Console.Clear();

            do
            {
                Console.WriteLine("Enter guessesNumber!");
                isBreak = GetResponse(guess[GuessCoreKeys.Interactors.GetGuessesNamberInteractorKey]);
            } while (!isBreak);
            Console.Clear();
            
            do
            {
                Console.WriteLine("Enter namber!");
                isBreak = GetResponse(guess[GuessCoreKeys.Interactors.GuessInteractorKey]);
            } while (!isBreak);
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

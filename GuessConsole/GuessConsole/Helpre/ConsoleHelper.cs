using System;
using GuessCore.Interfaсes;

namespace GuessConsole.Helpre
{
    public static class ConsoleHelper
    {
        public static bool GetResponse(IInteractor interactor, string str)
        {
            var res = interactor.Interact(str);
            Console.WriteLine(res.Massage);
            return res.IsSuccessfulOperation;
        }
    }
}
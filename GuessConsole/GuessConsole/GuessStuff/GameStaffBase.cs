using GuessConsole.Interfases;
using GuessCore.Facade;
using GuessCore.Interfaсes;

namespace GuessConsole.GuessStuff
{
    public abstract class GameStaffBase
    {
        protected IGuessFacade _Guess;

        protected GameStaffBase()
        {
            _Guess = new GuessFacade();
        }

    }
}
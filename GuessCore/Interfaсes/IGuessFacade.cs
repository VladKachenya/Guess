using GuessCore.Helpers;

namespace GuessCore.Interfaсes
{
    public interface IGuessFacade
    {
        void Initialize();
        IRetryCounter GetRetryCounter();
        IInteractor this[InteractorKey key] { get; }
    }
}
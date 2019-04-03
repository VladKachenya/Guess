using System.Collections.Generic;

namespace GuessCore.Interfaсes.Facade
{
    public interface IFacadeExternal
    {
        void Initialize();
        IInteractor this[string key] { get; }
    }
}
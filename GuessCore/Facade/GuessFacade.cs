using System.Collections.Generic;
using GuessCore.Helpers;
using GuessCore.Interactors;
using GuessCore.Interfaсes;
using GuessCore.Interfaсes.Facade;
using GuessCore.Interfaсes.Factories;

namespace GuessCore.Facade
{
    public class GuessFacade : IFacadeExternal
    {
        private readonly IRespondentFactory _respondentFactory;

        public void Initialize()
        {
            _interactors.Add(GuessCoreKeys.Interactors.LoginInteractorKey, new GuessInteractor(_respondentFactory.GetRespondent()));
        }

        public IInteractor this[string key] => _interactors[key];

        private Dictionary<string, IInteractor> _interactors;

        public GuessFacade(IRespondentFactory respondentFactory)
        {
            _respondentFactory = respondentFactory;
            _interactors = new Dictionary<string, IInteractor>();
        }
    }
}
using System.Collections.Generic;
using GuessCore.Converters;
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
            var respondent = _respondentFactory.GetRespondent();
            var toIntConverter = new ToIntConverter();
            _interactors.Add(GuessCoreKeys.Interactors.GuessInteractorKey, new GuessInteractor(respondent, toIntConverter));
            _interactors.Add(GuessCoreKeys.Interactors.RespondentConfigureInteractorKey, new RespondentConfigureInteractor(respondent, toIntConverter));

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
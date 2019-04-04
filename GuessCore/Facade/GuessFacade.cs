using System.Collections.Generic;
using GuessCore.Converters;
using GuessCore.Helpers;
using GuessCore.Interactors;
using GuessCore.Interfaсes;
using GuessCore.ProcessEntitys;

namespace GuessCore.Facade
{
    public class GuessFacade : IGuessFacade
    {
        private IRetryCounter _retryCounter;

        public void Initialize()
        {
            var respondent = new Respondent();
            _retryCounter = respondent;
            var toIntConverter = new ToIntConverter();
            _interactors.Add(InteractorKey.Guess, new GuessInteractor(respondent, toIntConverter));
            _interactors.Add(InteractorKey.RespondentAutoConfigure, new  RespondentAutoConfigureInteractor(respondent, new ToLevelConverter()));
            _interactors.Add(InteractorKey.RespondentManualConfigure, new RespondentManualConfigureInteractor(respondent, toIntConverter));
            _interactors.Add(InteractorKey.Login, new LoginInteractor());
        }

        public IRetryCounter GetRetryCounter()
        {
            return _retryCounter;
        }

        public IInteractor this[InteractorKey key] => _interactors[key];

        private Dictionary<InteractorKey, IInteractor> _interactors;

        public GuessFacade()
        {
            _interactors = new Dictionary<InteractorKey, IInteractor>();
        }
    }
}
using GuessCore.Converters;
using GuessCore.Helpers;
using GuessCore.Interactors;
using GuessCore.Interfaсes;
using GuessCore.ProcessEntitys;
using System.Collections.Generic;
using GuessInfrastructure.Model;
using GuessInfrastructure.Repository;

namespace GuessCore.Facade
{
    public class GuessFacade : IGuessFacade
    {
        #region private filds
        private IRetryCounter _retryCounter;
        private Dictionary<InteractorKey, IInteractor> _interactors;
        private Player _player;
        #endregion
        public GuessFacade()
        {
            _interactors = new Dictionary<InteractorKey, IInteractor>();
        }

        public void Initialize()
        {
            var respondent = new Respondent();
            _retryCounter = respondent;
            var toIntConverter = new ToIntConverter();
            var playerRepository = new PlayerRepository();
            _interactors.Clear();
            _interactors.Add(InteractorKey.Guess, new GuessInteractor(respondent, toIntConverter));
            _interactors.Add(InteractorKey.RespondentAutoConfigure, new RespondentAutoConfigureInteractor(respondent, new ToLevelConverter()));
            _interactors.Add(InteractorKey.RespondentManualConfigure, new RespondentManualConfigureInteractor(respondent, toIntConverter));
            _interactors.Add(InteractorKey.Login, new LoginInteractor(playerRepository, el => _player = el));
            _interactors.Add(InteractorKey.SaveCurentPlayer, new SaveCurentPlayerInteractor(playerRepository, respondent, () => _player));

        }

        public IRetryCounter GetRetryCounter()
        {
            return _retryCounter;
        }

        public IInteractor this[InteractorKey key] => _interactors[key];

        public string GetPlayerState()
        {
            if (_player == null)
            {
                return "Игрок не установлен";
            }
            return $"{_player.Name} : {_player.Score}";
        }
         
    }
}
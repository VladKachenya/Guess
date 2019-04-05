using System;
using GuessCore.Helpers;
using GuessCore.Interfaсes;
using GuessInfrastructure.Interfaces;
using GuessInfrastructure.Model;

namespace GuessCore.Interactors
{
    public class SaveCurentPlayerInteractor : IInteractor
    {
        private readonly IPlayerSaver _playerSaver;
        private readonly IRespondent _respondent;
        private readonly Func<Player> _getCurentPlayer;


        public SaveCurentPlayerInteractor(IPlayerSaver playerSaver, IRespondent respondent, Func<Player> getCurentPlayer)
        {
            _playerSaver = playerSaver;
            _respondent = respondent;
            _getCurentPlayer = getCurentPlayer;

        }
        public OperationResult Interact(string request)
        {
            try
            {
                var player = _getCurentPlayer();
                var toAdd = _respondent.NumberOfAttempts - _respondent.Attempts;
                var res = player.Score + toAdd;
                var resStr = $"Ваш результат : {player.Score} + {toAdd} = {res}";
                player.Score = res;
                _playerSaver.SavePlayer(player);
                return new OperationResult(true, resStr);
            }
            catch (Exception e)
            {
                return new OperationResult(false, e.Message);
            }


        }
    }
}
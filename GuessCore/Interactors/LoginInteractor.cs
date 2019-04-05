using System;
using GuessCore.Helpers;
using GuessCore.Interfaсes;
using GuessInfrastructure.Interfaces;
using GuessInfrastructure.Model;

namespace GuessCore.Interactors
{
    public class LoginInteractor : IInteractor
    {
        private readonly IPlayerGetter _playerGetter;
        private readonly Action<Player> _setPlayerAction;

        public LoginInteractor(IPlayerGetter playerGetter, Action<Player> setPlayerAction)
        {
            _playerGetter = playerGetter;
            _setPlayerAction = setPlayerAction;
        }
        public OperationResult Interact(string request)
        {
            if (string.IsNullOrWhiteSpace(request))
            {
                return new OperationResult(false, "Введите своё имя");
            }
            if (!StaticStringValidationHelper.NameValidation(request))
            {
                return new OperationResult(false, "Имя ведено неверно");
            }

            if (request.Length < 4)
            {
                return new OperationResult(false, "Имя должно быть не менее четырёх символов");
            }

            _setPlayerAction.Invoke(_playerGetter.GetPlayer(request));
            return new OperationResult();
        }
    }
}
using GuessCore.Helpers;
using GuessCore.Interactors.Base;
using GuessCore.Interfaсes;
using GuessInfrastructure.Model;
using System;

namespace GuessCore.Interactors
{
    public class RespondentAutoConfigureInteractor : InteractorBase<LevelKey>, IInteractor
    {
        private readonly Func<Player> _getPlayer;
        private Random random = new Random();
        public RespondentAutoConfigureInteractor(IRespondent respondent, IConverter<LevelKey> converter, Func<Player> getPlayer) : base(respondent, converter)
        {
            _getPlayer = getPlayer;
        }

        public OperationResult Interact(string request)
        {
            if (string.IsNullOrWhiteSpace(request))
            {
                return new OperationResult(false, "Выберите сложность (Easy, Medium, Hard):");
            }
            var res = this.ToTParser(out var level, request);
            if (!res.IsSuccessfulOperation)
            {
                return res;
            }

            switch (level)
            {
                case LevelKey.Easy: ConfigureRespondent(10); break;
                case LevelKey.Medium: ConfigureRespondent(100); break;
                case LevelKey.Hard: ConfigureRespondent(1000); break;
            }

            _getPlayer().GameCounter++;
            return new OperationResult();
        }

        private void ConfigureRespondent(int range)
        {
            _respondent.MinNamber = random.Next(0, 10000 - range);
            _respondent.MaxNamber = _respondent.MinNamber + range;
            _respondent.SetNuberOfAttempts();
            _respondent.GuessesNamber = random.Next(_respondent.MinNamber.Value, _respondent.MaxNamber.Value);
        }
    }
}
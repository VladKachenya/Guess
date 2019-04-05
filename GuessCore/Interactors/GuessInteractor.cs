using GuessCore.Helpers;
using GuessCore.Interactors.Base;
using GuessCore.Interfaсes;
using System;
using System.Collections.Generic;

namespace GuessCore.Interactors
{
    public class GuessInteractor : InteractorBase<int>, IInteractor
    {
        private string _range =>
            $"Загаданное число находится в диапазоне  [{_respondent.MinNamber},{_respondent.MaxNamber}]";
        public GuessInteractor(IRespondent respondent, IConverter<int> converter)
            : base(respondent, converter)
        {

        }
        public OperationResult Interact(string request)
        {
            if (string.IsNullOrWhiteSpace(request))
            {
                return new OperationResult(false, _range);
            }
            var res = this.ToTParser(out var nam, request);
            if (!res.IsSuccessfulOperation)
            {
                return res;
            }

            if (!_respondent.IsAttemptsRemained)
            {
                return new OperationResult(false, $"Вы израсходывали все свои попытки");
            }
            var tryGuessRes = _respondent.TryGuess(nam);
            if (tryGuessRes < 0)
            {
                return new OperationResult(false, $"{_range} и больше {nam}");
            }
            if (tryGuessRes > 0)
            {
                return new OperationResult(false, $"{_range} и меньше {nam}");
            }
            return new OperationResult(true, "Вы победили!");
        }
    }
}
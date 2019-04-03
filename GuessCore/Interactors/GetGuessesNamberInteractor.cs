using System.Collections.Generic;
using GuessCore.Helpers;
using GuessCore.Interactors.Base;
using GuessCore.Interfaсes;

namespace GuessCore.Interactors
{
    public class GetGuessesNamberInteractor : GetInteractorBase, IInteractor
    {

        public GetGuessesNamberInteractor(IRespondent respondent, IConverter<int> converter)
            : base(respondent, converter)
        {

        }
        public OperationResult Interact(string request)
        {
            var resList = new List<string>();
            var res = this.ToIntParser(out var nam, request);
            if (!res.IsSuccessfulOperation)
            {
                return res;
            }

            if (nam > _respondent.MaxNamber || nam < _respondent.MinNamber)
            {
                resList.Add($"Число {nam} находится вне заданного диапазона [{_respondent.MinNamber}, {_respondent.MaxNamber}]");
                return new OperationResult(false, resList);
            }

            _respondent.GuessesNamber = nam;
            return new OperationResult();

        }
    }
}
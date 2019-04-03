using GuessCore.Helpers;
using GuessCore.Interactors.Base;
using GuessCore.Interfaсes;
using System.Collections.Generic;

namespace GuessCore.Interactors
{
    public class GetMaxNambInteractor : GetInteractorBase, IInteractor
    {
        public GetMaxNambInteractor(IRespondent respondent, IConverter<int> converter)
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

            if (_respondent.MinNamber + 2 >= nam)
            {
                resList.Add($"Максимальное значение не может быть меньше или равным {_respondent.MinNamber + 2}");
                return new OperationResult(false, resList);
            }

            _respondent.MaxNamber = nam;
            return new OperationResult();

        }
    }
}
using GuessCore.Helpers;
using GuessCore.Interfaсes;
using System;
using System.Collections.Generic;
using GuessCore.Interactors.Base;

namespace GuessCore.Interactors
{
    public class GetMinNumbInteractor : GetInteractorBase, IInteractor
    {
        public GetMinNumbInteractor(IRespondent respondent, IConverter<int> converter)
            : base(respondent, converter)
        {}

        public OperationResult Interact(string request)
        {
            var resList = new List<string>();
            var res = this.ToIntParser(out var nam, request);
            if (!res.IsSuccessfulOperation)
            {
                return res;
            }

            if (nam < 0)
            {
                resList.Add("Минимальное значение не может быть меньше нуля");
                return new OperationResult(false, resList);
            }

            _respondent.MinNamber = nam;
            return new OperationResult();
        }
    }
}
using GuessCore.Helpers;
using GuessCore.Interactors.Base;
using GuessCore.Interfaсes;
using System.Collections.Generic;

namespace GuessCore.Interactors
{
    public class RespondentConfigureInteractor : GetInteractorBase, IInteractor
    {
        public RespondentConfigureInteractor(IRespondent respondent, IConverter<int> converter)
            : base(respondent, converter)
        {

        }

        public OperationResult Interact(string request)
        {
            var resList = new List<string>();
            if (_respondent.MinNamber == null)
            {
                if (string.IsNullOrWhiteSpace(request))
                {
                    resList.Add("Задайте минимальное число");
                    return new OperationResult(false, resList);
                }

                var res = this.ToIntParser(out var nam, request);
                if (!res.IsSuccessfulOperation)
                {
                    return res;
                }

                if (nam < 0)
                {
                    resList.Add("Минимальное число не может быть отрицательным");
                    return new OperationResult(false, resList);
                }

                _respondent.MinNamber = nam;
                request = "";
            }


            if (_respondent.MaxNamber == null)
            {
                if (string.IsNullOrWhiteSpace(request))
                {
                    resList.Add("Задайте максимальное число диапазона");
                    return new OperationResult(false, resList);
                }

                var res = this.ToIntParser(out var nam, request);
                if (!res.IsSuccessfulOperation)
                {
                    return res;
                }

                if (nam < _respondent.MinNamber + 2)
                {
                    resList.Add($"Максимальное чило не может быть меньшим {_respondent.MinNamber + 2}");
                    return new OperationResult(false, resList);
                }

                _respondent.MaxNamber = nam;
                request = "";
            }

            if (_respondent.GuessesNamber == null)
            {
                if (string.IsNullOrWhiteSpace(request))
                {
                    resList.Add($"Загадайте число из диапазона [{_respondent.MinNamber},{_respondent.MaxNamber}]");
                    return new OperationResult(false, resList);
                }

                var res = this.ToIntParser(out var nam, request);
                if (!res.IsSuccessfulOperation)
                {
                    return res;
                }

                if (nam < _respondent.MinNamber || nam > _respondent.MaxNamber)
                {
                    resList.Add(
                        $"Число {nam} находится вне диапазоно  [{_respondent.MinNamber},{_respondent.MaxNamber}]");
                    return new OperationResult(false, resList);
                }

                _respondent.MaxNamber = nam;
            }
            return new OperationResult();
        }
    }
}
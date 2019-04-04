using GuessCore.Helpers;
using GuessCore.Interactors.Base;
using GuessCore.Interfaсes;
using System.Collections.Generic;

namespace GuessCore.Interactors
{
    public class RespondentManualConfigureInteractor : InteractorBase<int>, IInteractor
    {
        public RespondentManualConfigureInteractor(IRespondent respondent, IConverter<int> converter)
            : base(respondent, converter)
        {

        }

        public OperationResult Interact(string request)
        {
            if (_respondent.MinNamber == null)
            {
                if (string.IsNullOrWhiteSpace(request))
                {
                    return new OperationResult(false, "Задайте минимальное число");
                }

                var res = this.ToTParser(out var nam, request);
                if (!res.IsSuccessfulOperation)
                {
                    return res;
                }

                if (nam < 0)
                {
                    return new OperationResult(false, "Минимальное число не может быть отрицательным");
                }

                _respondent.MinNamber = nam;
                request = "";
            }


            if (_respondent.MaxNamber == null)
            {
                if (string.IsNullOrWhiteSpace(request))
                {
                    return new OperationResult(false, "Задайте максимальное число диапазона");
                }

                var res = this.ToTParser(out var nam, request);
                if (!res.IsSuccessfulOperation)
                {
                    return res;
                }

                if (nam < _respondent.MinNamber + 2)
                {
                    return new OperationResult(false, $"Максимальное чило не может быть меньшим {_respondent.MinNamber + 2}");
                }

                _respondent.MaxNamber = nam;
                _respondent.SetNuberOfAttempts();
                request = "";
            }

            if (_respondent.GuessesNamber == null)
            {
                if (string.IsNullOrWhiteSpace(request))
                {
                    return new OperationResult(false, $"Загадайте число из диапазона [{_respondent.MinNamber},{_respondent.MaxNamber}]");
                }

                var res = this.ToTParser(out var nam, request);
                if (!res.IsSuccessfulOperation)
                {
                    return res;
                }

                if (nam < _respondent.MinNamber || nam > _respondent.MaxNamber)
                {
                    return new OperationResult(false, $"Число {nam} находится вне диапазоно  [{_respondent.MinNamber},{_respondent.MaxNamber}]");
                }

                _respondent.GuessesNamber = nam;
            }
            return new OperationResult();
        }
    }
}
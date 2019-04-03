using GuessCore.Helpers;
using GuessCore.Interfaсes;
using System.Collections.Generic;

namespace GuessCore.Interactors
{
    public class GuessInteractor : IInteractor
    {
        private readonly IRespondent _respondent;

        public GuessInteractor(IRespondent respondent)
        {
            _respondent = respondent;
        }

        public OperationResult Interact(string request)
        {
            int nam = int.Parse(request);
            if (_respondent.TryToGuess(nam))
            {
                return new OperationResult();
            }
            return new OperationResult(false, new List<string>());
        }
    }
}
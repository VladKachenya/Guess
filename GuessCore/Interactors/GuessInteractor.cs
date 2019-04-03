﻿using GuessCore.Helpers;
using GuessCore.Interactors.Base;
using GuessCore.Interfaсes;
using System;
using System.Collections.Generic;

namespace GuessCore.Interactors
{
    public class GuessInteractor : GetInteractorBase, IInteractor
    {
        public GuessInteractor(IRespondent respondent, IConverter<int> converter)
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
            
            if (_respondent.TryToGuess(nam))
            {
                return new OperationResult();
            }
            return new OperationResult(false, new List<string>());
        }
    }
}
using System;
using System.Collections.Generic;
using GuessCore.Helpers;
using GuessCore.Interfaсes;

namespace GuessCore.Interactors.Base
{
    public abstract class GetInteractorBase
    {
        protected IRespondent _respondent;
        protected IConverter<int> _converter;

        public GetInteractorBase(IRespondent respondent, IConverter<int> converter)
        {
            _respondent = respondent;
            _converter = converter;
        }

        protected OperationResult ToIntParser(out int res, string str)
        {
            var resList = new List<string>();
            res = 0;
            try
            {
                res = _converter.Convert(str);
            }
            catch (Exception e)
            {
                resList.Add(e.Message);
                return new OperationResult(false, resList);
            }
            return new OperationResult();
        }
    }
}
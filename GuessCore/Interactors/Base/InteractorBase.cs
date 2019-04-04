using System;
using System.Collections.Generic;
using GuessCore.Helpers;
using GuessCore.Interfaсes;

namespace GuessCore.Interactors.Base
{
    public abstract class InteractorBase<T>
    {
        protected IRespondent _respondent;
        protected IConverter<T> _converter;

        public InteractorBase(IRespondent respondent, IConverter<T> converter)
        {
            _respondent = respondent;
            _converter = converter;
        }

        protected OperationResult ToTParser(out T res, string str)
        {
            var resList = new List<string>();
            res = default(T);
            try
            {
                res = _converter.Convert(str);
            }
            catch (Exception e)
            {
                return new OperationResult(false, e.Message);
            }
            return new OperationResult();
        }
    }
}
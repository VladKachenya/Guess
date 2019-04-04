using System.Collections.Generic;

namespace GuessCore.Helpers
{
    public class OperationResult
    {
        public OperationResult()
        {
            IsSuccessfulOperation = true;
            Massage = "OperationComplite";
        }
        public OperationResult(bool isSuccess, string massages)
        {
            IsSuccessfulOperation = isSuccess;
            Massage = massages;
        }
        public bool IsSuccessfulOperation { get; }

        public string Massage { get; }
    }
}
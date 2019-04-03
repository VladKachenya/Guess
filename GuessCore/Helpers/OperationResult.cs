using System.Collections.Generic;

namespace GuessCore.Helpers
{
    public class OperationResult
    {
        public OperationResult()
        {
            IsSuccessfulOperation = true;
            MassageList = new List<string>();
            MassageList.Add("OperationComplite");
        }
        public OperationResult(bool IsSuccess, List<string> massages)
        {
            IsSuccessfulOperation = IsSuccess;
            MassageList = massages;
        }
        public bool IsSuccessfulOperation { get; }

        public List<string> MassageList { get; }
    }
}
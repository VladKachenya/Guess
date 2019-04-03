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
        public OperationResult(bool IsSuccess, IEnumerable<string> massages)
        {
            IsSuccessfulOperation = IsSuccess;
            MassageList = new List<string>(massages);
        }
        public bool IsSuccessfulOperation { get; }

        public List<string> MassageList { get; }
    }
}
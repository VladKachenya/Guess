using GuessCore.Interfaсes;

namespace GuessCore.ProcessEntitys
{
    public class Respondent : IRespondent
    {

        public int? MaxNamber { get; set; }
        public int? MinNamber { get; set; }
        public int? GuessesNamber { get; set; }
        public int NumberOfAttempts { get; protected set; }
        public int Attempts { get; protected set; }
        public bool IsAttemptsRemained => NumberOfAttempts != Attempts;

        public int TryGuess(int num)
        {
            if (IsAttemptsRemained)
            {
                Attempts++;
            }

            if (num > GuessesNamber)
            {
                return 1;
            }

            if (num < GuessesNamber)
            {
                return -1;
            }

            return 0;
        }

        public void SetNuberOfAttempts()
        {
            var length = MaxNamber - MinNamber;
            NumberOfAttempts = 1;
            var sum = 2;
            while (sum < length)
            {
                sum *= 2;
                NumberOfAttempts++;
            }
        }
    }
}
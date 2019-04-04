namespace GuessCore.Interfaсes
{
    public interface IRetryCounter
    {
        int NumberOfAttempts { get; }
        int Attempts { get; }

        bool IsAttemptsRemained { get; }
    }
}
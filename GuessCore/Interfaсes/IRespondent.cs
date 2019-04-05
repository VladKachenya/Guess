namespace GuessCore.Interfaсes
{
    public interface IRespondent : IRetryCounter
    {
        int? MaxNamber { get; set; }
        int? MinNamber { get; set; }
        int? GuessesNamber { get; set; }
        void SetNuberOfAttempts();
        int TryGuess(int num);

    }
}
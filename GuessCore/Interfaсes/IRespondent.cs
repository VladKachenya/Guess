namespace GuessCore.Interfaсes
{
    public interface IRespondent
    {
        int? MaxNamber { get; set; }
        int? MinNamber { get; set; }
        int? GuessesNamber { get; set; }

        bool TryToGuess(int i);
    }
}
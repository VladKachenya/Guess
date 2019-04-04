using GuessCore.Interfaсes;

namespace GuessCore.Respondents
{
    public class TestRespondent : IRespondent
    {
        private readonly int _guessing;

        public TestRespondent(int guessing)
        {
            _guessing = guessing;
        }

        public int? MaxNamber { get; set; }
        public int? MinNamber { get; set; }
        public int? GuessesNamber { get; set; }

        public bool TryToGuess(int nam)
        {
            return nam == _guessing;
        }
    }
}
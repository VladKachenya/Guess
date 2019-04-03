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
        public bool TryToGuess(int nam)
        {
            return nam == _guessing;
        }
    }
}
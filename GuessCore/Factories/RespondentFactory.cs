using GuessCore.Interfaсes;
using GuessCore.Interfaсes.Factories;
using GuessCore.Respondents;

namespace GuessCore.Factories
{
    public class RespondentFactory : IRespondentFactory
    {

        public IRespondent GetRespondent()
        {
            return new TestRespondent(5);
        }
    }
}
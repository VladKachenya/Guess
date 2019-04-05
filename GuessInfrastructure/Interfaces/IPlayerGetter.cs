using GuessInfrastructure.Model;

namespace GuessInfrastructure.Interfaces
{
    public interface IPlayerGetter
    {
        Player GetPlayer(string name);
    }
}
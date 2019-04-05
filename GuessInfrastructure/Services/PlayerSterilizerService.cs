using GuessInfrastructure.Interfaces;
using GuessInfrastructure.Model;
using Newtonsoft.Json;

namespace GuessInfrastructure.Services
{
    public class PlayerSterilizerService : ISterilizer<Player>
    {
        public string Sterilize(Player entity)
        {

            return JsonConvert.SerializeObject(entity);
        }

        public Player DeSterilize(string str)
        {
            return JsonConvert.DeserializeObject<Player>(str);
        }
    }
}
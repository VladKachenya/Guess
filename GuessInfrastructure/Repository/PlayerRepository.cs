using System;
using System.IO;
using GuessInfrastructure.Interfaces;
using GuessInfrastructure.Model;
using GuessInfrastructure.Services;

namespace GuessInfrastructure.Repository
{
    public class PlayerRepository: IPlayerGetter, IPlayerSaver
    {
        private readonly string  _currentDirectory;
        private readonly string _folderName;
        private ISterilizer<Player> _sterilizer;

        public PlayerRepository()
        {
            _sterilizer = new PlayerSterilizerService();
            _currentDirectory = Environment.CurrentDirectory;
            _folderName = "Player";
            var folderPath = Path.Combine(_currentDirectory, _folderName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

        }
        public Player GetPlayer(string name)
        {
            var fileName = $"{name}.json";
            var path = Path.Combine(_currentDirectory, _folderName, fileName);
            if (!File.Exists(path))
            {
                return new Player() {Name = name};
            }
            using (var sw = new StreamReader(path))
            {
                var json = sw.ReadToEnd();
                return _sterilizer.DeSterilize(json);
            }

        }

        public void SavePlayer(Player player)
        {
            var fileName = $"{player.Name}.json";
            var path = Path.Combine(_currentDirectory, _folderName, fileName);
            using (var sw = new StreamWriter(path))
            {
                sw.Write(_sterilizer.Sterilize(player));
            }
        }

    }
}
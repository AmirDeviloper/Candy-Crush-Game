using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace candy_project.Models
{
    public class Player
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public List<int> Recodes { get; private set; }
        public int PlayedGamesCount { get; private set; }
        public List<Player> Friednds { get; private set; }
        public int WinsCount { get; private set; }
        public int LosesCount { get; private set; }

        public string GenerateUniqeId()
        {
            throw new NotImplementedException();
        }

        public Player() 
        {

        }
    }
}

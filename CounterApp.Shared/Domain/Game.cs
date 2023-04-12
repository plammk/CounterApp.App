using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterApp.Shared.Domain
{
    public class Game
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public List<Player> PlayersList { get; set; } = new List<Player>();

        public int CurrPlayerId { get; set; } = 1;

        public bool Finished { get; set; } = false;

        public Player? Winner { get; set; } = default!;

    }
}

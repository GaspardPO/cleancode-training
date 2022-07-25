using System;
using System.Collections.Generic;
using System.Text;

namespace Trivia
{
    public class Player
    {
        public string Name { get; }

        public int Coins { get; set; }

        public Player(string name, int coins)
        {
            Name = name;
            Coins = coins;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

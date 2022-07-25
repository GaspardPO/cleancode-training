using System;
using System.Collections.Generic;
using System.Text;

namespace Trivia
{
    public class Player
    {
        public string Name { get; }

        public Player(string name)
        {
            Name = name;    
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

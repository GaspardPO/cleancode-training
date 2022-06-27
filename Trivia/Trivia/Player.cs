using System;
using System.Collections.Generic;

namespace Trivia
{
    public class Player
    {
        private string name;

        public Player(string name)
        {
            this.name = name;
        }

        public bool IsInPenaltyBox => false; 

        public int GetPosition()
        {
            return 0;
        }

        public int GetPurse()
        {
            return 0;
        }

        public string GetName()
        {
            return name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
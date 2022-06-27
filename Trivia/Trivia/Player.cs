using System;

namespace Trivia
{
    public class Player
    {
        private string name;
        private int position;

        public Player(string name)
        {
            this.name = name;
        }

        public bool IsInPenaltyBox => false;

        public int GetPosition()
        {
            return position;
        }

        public int GetScore()
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

        public void Move(int roll)
        {
            position += roll;
        }

        public void Score()
        {
            throw new NotImplementedException();
        }
    }
}
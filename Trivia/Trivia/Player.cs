using System;

namespace Trivia
{
    public class Player
    {
        private string name;
        private int position;
        private int score;
        private bool isInPenaltyBox;

        public Player(string name)
        {
            this.name = name;
        }

        public bool IsInPenaltyBox => isInPenaltyBox;

        public int GetPosition()
        {
            return position;
        }

        public int GetScore()
        {
            return score;
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
            score++;
        }

        public void GoToPenaltyBox()
        {
            isInPenaltyBox = true;
        }
    }
}
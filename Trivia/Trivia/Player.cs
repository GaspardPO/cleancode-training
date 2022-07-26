namespace Trivia
{
    public class Player
    {
        public string Name { get; }

        public int Coins { get; set; } = 0;

        public bool IsInPenaltyBox { get; private set; }

        public Player(string name)
        {
            Name = name;
        }

        public override string ToString() => Name;
        
        public void EarnCoin() => Coins += 1;

        public void GoToPenaltyBox() => IsInPenaltyBox = true;

    }
}

namespace Trivia
{
    public class Player
    {
        public string Name { get; }

        public int Coins { get; set; } = 0;

        public Player(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public void EarnCoin() => Coins += 1;
    }
}

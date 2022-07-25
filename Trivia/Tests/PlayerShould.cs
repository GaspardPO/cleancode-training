using Trivia;
using Xunit;

namespace Tests
{
    public class PlayerShould
    {
        [Fact]
        public void Begin_with_empty_purse()
        {
            Assert.Equal(0, new Player("MyPlayerName").Coins);
        }

        [Fact]
        public void Show_his_name()
        {
            var player = new Player("MyPlayerName");
            Assert.Equal("MyPlayerName", player.ToString());
        }

        [Fact]
        public void Earn_coin_after_coin()
        {
            var player = new Player("MyPlayerName");
            player.EarnCoin();
            Assert.Equal(1, player.Coins);
            player.EarnCoin();
            Assert.Equal(2, player.Coins);
        }
    }
}

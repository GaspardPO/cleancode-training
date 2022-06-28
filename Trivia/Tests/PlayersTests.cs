using System.Collections.Generic;

using Trivia;

using Xunit;

namespace Tests
{
    public class PlayersTests
    {
        [Fact]
        public void Should()
        {
            // Arrange

            // Act
            var players = new Players(new Player("Julien"), new Player("Fabien"));

            // Assert
            Assert.Equal(2, players.Count);
        }
    }

    public class Players
    {
        private readonly List<Player> _players = new List<Player>();

        public Players(Player player1, Player player2)
        {
            _players.Add(player1);
            _players.Add(player2);
        }

        public int Count => _players.Count;
    }
}

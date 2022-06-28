using Trivia;

using Xunit;

namespace Tests
{
    public class PlayersTests
    {
        [Fact]
        public void Should_create_players_with_correct_player_count()
        {
            // Arrange

            // Act
            var players = new Players(new Player("Julien"), new Player("Fabien"));

            // Assert
            Assert.Equal(2, players.Count);
        }
        
        [Fact]
        public void Should_add_new_player()
        {
            // Arrange
            var players = new Players(new Player("Julien"), new Player("Fabien"));
            // Act
            players.Add(new Player("Yasmine"));
            // Assert
            Assert.Equal(3, players.Count);
        }
    }
}

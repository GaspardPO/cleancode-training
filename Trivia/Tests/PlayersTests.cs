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

        [Fact]
        public void Should_get_current_player()
        {
            // Arrange
            var players = new Players(new Player("Julien"), new Player("Fabien"));

            // Act
            var player = players.Current();

            // Assert
            Assert.Equal("Julien", player.GetName());
        }

        [Fact]
        public void Should_get_next_player()
        {
            // Arrange
            var players = new Players(new Player("Julien"), new Player("Fabien"));

            // Act
            players.Next();
            var player = players.Current();

            // Assert
            Assert.Equal("Fabien", player.GetName());
        }

        [Fact]
        public void Should_get_the_first_player_when_all_players_have_played()
        {
            // Arrange
            var players = new Players(new Player("Julien"), new Player("Fabien"));

            // Act
            players.Next();
            players.Next();
            var player = players.Current();

            // Assert
            Assert.Equal("Julien", player.GetName());
        }
    }
}

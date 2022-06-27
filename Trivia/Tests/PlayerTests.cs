using Trivia;
using Xunit;

namespace Tests
{
    public class PlayerTests
    {
        [Fact]
        public void Should_be_initialized()
        {
            //Act
            var player = new Player("Jack");

            //Assert
            Assert.Equal(0, player.GetPosition());
            Assert.Equal(0, player.GetPurse());
            Assert.False(player.IsInPenaltyBox);
            Assert.Equal("Jack", player.GetName());
        }

        [Fact]
        public void Should_move_player_with_roll_value()
        {
            //Arrange
            var player = new Player("Jack");
            int roll = 4;

            // Act
            player.Move(roll);

            //Assert
            Assert.Equal(roll, player.GetPosition());
        }
    }
}

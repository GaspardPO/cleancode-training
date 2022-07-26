using System;
using System.Collections.Generic;
using System.Text;
using Trivia;
using Xunit;

namespace Tests
{
    public class BoardTest
    {
        [Fact]
        public void Starting_position_is_always_zero()
        {
            var board = new Board();
            Player player = new Player("PlayerOne");

            board.PlaceAtStart(player);

            Assert.Equal(0, board.GetPosition(player));
        }

        [Fact]
        public void Move_player_should_change_position()
        {
            var board = new Board();
            Player player = new Player("PlayerOne");
            board.PlaceAtStart(player);

            board.MoveForward(player, 3);

            Assert.Equal(3, board.GetPosition(player));
        }

        [Fact]
        public void Move_player_should_over_the_12_limit()
        {
            var board = new Board();
            Player player = new Player("PlayerOne");
            board.PlaceAtStart(player);

            board.MoveForward(player, 11);
            board.MoveForward(player, 5);

            Assert.Equal(4, board.GetPosition(player));
        }
    }
}

using System;

using Trivia;

using Xunit;

namespace Tests
{
    public class DieTests
    {
        [Theory]
        [InlineData(12)]
        [InlineData(0)]
        public void Should_throw_error_if_roll_is_not_valid(int roll)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Die(roll));
        }

        [Fact]
        public void Should_be_equal_to_another_die_with_same_value()
        {
            // Assert
            Assert.Equal(new Die(6), new Die(6));
            Assert.True(new Die(6) == new Die(6));
        }
    }
}

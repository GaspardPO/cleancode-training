using Trivia;
using Xunit;

namespace Tests
{
    public class DeckTest
    {
        [Fact]
        public void Create_a_pop_deck()
        {
            var deck = new Deck(Question.Categories.Pop, 40);

            var question = deck.Draw();

            Assert.Contains("Pop", question.ToString());
        }

        //Draw une carte donne bien la première, qui n'y est plus après
        
    }
}

using System;
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

        [Fact]
        public void Draw_a_card_removed_it()
        {
            var deck = new Deck(Question.Categories.Pop, 30);

            var question0 = deck.Draw();
            var question1 = deck.Draw();

            Assert.Contains("0",question0.ToString());
            Assert.Contains("1",question1.ToString());
        }

        [Fact]
        public void Draw_out_of_deck_throw_an_exception()
        {
            var deck = new Deck(Question.Categories.Pop, 2);

            deck.Draw();
            deck.Draw();

            Assert.Throws<InvalidOperationException>(() => deck.Draw());
        }
    }
}

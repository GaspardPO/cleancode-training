using System;
using System.Collections.Generic;

namespace Trivia
{
    public class MainDeck
    {
        private readonly Dictionary<Question.Categories, Deck> _deckCategories = new Dictionary<Question.Categories, Deck>();

        public MainDeck(int size)
        {
            foreach (Question.Categories categorie in Enum.GetValues(typeof(Question.Categories)))
            {
                _deckCategories.Add(categorie, new Deck(categorie, size));
            }
        }

        public Question Draw(Question.Categories currentCategory)
        {
            return _deckCategories[currentCategory].Draw();
        }
    }
}
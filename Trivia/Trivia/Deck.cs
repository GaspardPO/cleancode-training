using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Deck
    {
        private readonly LinkedList<Question> _list = new LinkedList<Question>();

        public Deck(Question.Categories categorie, int deckSize)
        {
            for (var i = 0; i < deckSize; i++)
            {
                _list.AddLast(new Question(i, categorie));
            }
        }

        public Question Draw()
        {
            var question = _list.First();
            _list.RemoveFirst();

            return question;
        }
    }
}
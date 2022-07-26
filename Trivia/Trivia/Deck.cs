using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Deck
    {
        private readonly LinkedList<Question> _list = new LinkedList<Question>();

        public Deck()
        {
            for (var i = 0; i < 50; i++)
            {
                _list.AddLast(new Question(i, Question.Categories.Pop));
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
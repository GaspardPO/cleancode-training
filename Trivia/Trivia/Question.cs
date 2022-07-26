namespace Trivia
{
    public class Question
    {
        private int Index { get; }
        private Question.Categories Category { get; }

        public Question(int index, Question.Categories categories)
        {
            Index = index;
            Category = categories;
        }

        public override string ToString()
        {
            return Category + " Question " + Index;
        }

        public enum Categories
        {
            Sports,
            Rock,
            Pop,
            Science
        }
    }
}
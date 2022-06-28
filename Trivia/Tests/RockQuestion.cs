using Trivia;

namespace Tests
{
    internal class RockQuestion : Question
    {
        public RockQuestion(string label) : base(label)
        {
        }

        public override Categories GetCategory()
        {
            return Categories.Rock;
        }
    }
}
using Trivia;
using Xunit;

namespace Tests
{
    public class QuestionTest
    {
        [Fact]
        public void tostring_should_return_question()
        {
            Assert.Equal("Pop Question 5", new Question(5, Question.Categories.Pop).ToString());
        }
    }
}
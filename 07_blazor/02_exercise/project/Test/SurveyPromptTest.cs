using Blazor.Shared;
using Xunit;

namespace Test
{
    public class SurveyPromptTest
    {
        [Fact]
        public void SurveyTest()
        {
            var survey = new SurveyPrompt();
            Assert.Null(survey.Title);

            survey.Title = "title";
            Assert.Equal("title", survey.Title);
        }
    }
}
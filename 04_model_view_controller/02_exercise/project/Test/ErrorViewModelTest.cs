using App.Models;
using Xunit;

namespace Test
{
    public class ErrorViewModelTest
    {
        [Fact]
        public void RequestIdTest()
        {
            var errorViewModel = new ErrorViewModel();
            Assert.Null(errorViewModel.RequestId);
            Assert.False(errorViewModel.ShowRequestId);

            errorViewModel.RequestId = "";
            Assert.False(errorViewModel.ShowRequestId);

            errorViewModel.RequestId = "test";
            Assert.Equal("test", errorViewModel.RequestId);
            Assert.True(errorViewModel.ShowRequestId);
            
            
        }
    }
}
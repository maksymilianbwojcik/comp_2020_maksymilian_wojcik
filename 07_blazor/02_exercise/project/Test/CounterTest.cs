using Blazor.Pages;
using Xunit;

namespace Test
{
    public class CounterRazorTest
    {
        [Fact]
        public void CounterTest()
        {
            var counter = new Counter();
            
            Assert.Equal(0, counter.CurrentCount);

            counter.IncrementCount();
            
            Assert.Equal(1, counter.CurrentCount);
        }
    }
}
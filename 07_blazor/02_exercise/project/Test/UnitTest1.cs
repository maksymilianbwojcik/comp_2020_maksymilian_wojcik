using System;
using Blazor.Pages;
using Xunit;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void CounterTest()
        {
            var counter = new Counter();
            
            Assert.Equal(0, counter.currentCount);

            counter.IncrementCount();
            
            Assert.Equal(1, counter.currentCount);
        }
    }
}
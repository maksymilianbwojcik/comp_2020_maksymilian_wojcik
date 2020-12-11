using System;
using Utils;
using Xunit;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var fml = new NotMuchOfAUtility();
            
            Assert.Contains("Maks", fml.ViewName());
        }
    }
}
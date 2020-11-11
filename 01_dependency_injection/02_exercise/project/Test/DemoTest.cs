using System;
using System.IO;
using Microsoft.Extensions.Logging;
using Moq;
using Utils;
using Xunit;

namespace Test
{
    public class DemoTest
    {
//        [Fact]
//        public void Run()
//        {
//            var mock = new Mock<TextWriter>();
//            Console.SetOut(mock.Object);
//
//            const string name = "John";
//            mock.Setup(tw => tw.WriteLine($"Hello {name}!"));
//            
//            var demo = new Demo(name);
//            demo.Run();
//        }

        [Fact]
        public void Run()
        {
            var mock = new Mock<ILogger<Demo>>();
            const string name = "John";
            
            // mock.Setup(l => l.LogInformation($"Hello {name}!")).Verifiable();
            mock.Setup(l => l.LogInformation($"Hello {name}!")).Verifiable();
            
            var demo = new Demo(mock.Object);
            demo.Run(name);
            
            mock.Verify();
        }
    }
    
}
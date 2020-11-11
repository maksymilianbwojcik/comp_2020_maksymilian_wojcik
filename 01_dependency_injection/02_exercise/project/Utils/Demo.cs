using System;
using Microsoft.Extensions.Logging;

namespace Utils
{
    public class Demo
    {
        private readonly ILogger<Demo> _logger;

        public Demo(ILogger<Demo> logger)
        {
            _logger = logger;
        }

        public void Run(string name)
        {
            // Console.WriteLine($"Hello {_logger}!");
            _logger.LogInformation($"Hello {name}!");
        }
    }
}
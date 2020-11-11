using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Logging;

namespace Utils
{
    public class Demo
    {
        private readonly ILoggerAdapter<Demo> _logger;

        public Demo(ILoggerAdapter<Demo> logger)
        {
            _logger = logger;
        }

        public void Run(string name)
        {
            // Console.WriteLine($"Hello {_logger}!");
            _logger.LogInformation($"Hello {name}!");
        }
        
    }
    public interface ILoggerAdapter<T>
    {
        void LogInformation(string message);
    }

    [ExcludeFromCodeCoverage]
    public class LoggerAdapter<T> : ILoggerAdapter<Demo>
    {
        private readonly ILogger<Demo> _logger;

        public LoggerAdapter(ILogger<Demo> logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }
    }
}
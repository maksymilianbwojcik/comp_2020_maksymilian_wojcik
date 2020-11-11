using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Utils;

namespace App
{
    internal static class Program
    {
        [ExcludeFromCodeCoverage]
        private static void Main()
        {
            // var demo = new Demo("John");
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<ILoggerAdapter<Demo>, LoggerAdapter<Demo>>();
            serviceCollection.AddLogging(builder => builder.AddConsole());
            serviceCollection.AddScoped<Demo>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            
            var demo = serviceProvider.GetService<Demo>();
            demo.Run("John");
            
            serviceProvider.Dispose();
        }
    }
}

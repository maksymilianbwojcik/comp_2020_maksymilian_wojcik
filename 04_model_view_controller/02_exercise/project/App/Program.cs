// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Hosting;
// using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
// using Microsoft.Extensions.Logging;

namespace App
{
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /*public*/ private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
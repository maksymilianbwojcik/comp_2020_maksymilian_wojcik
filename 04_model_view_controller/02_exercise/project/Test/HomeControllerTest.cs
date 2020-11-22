using System;
using System.Net.Http;
using App.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;
using App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using Moq;

namespace Test
{
    public class HomeControllerTest
    {
        [Fact]
        public void IndexTest()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(configure => configure.AddConsole());
            serviceCollection.AddScoped<HomeController>();
            serviceCollection.AddScoped<ILogger<HomeController>, Logger<HomeController>>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var controller = serviceProvider.GetService<HomeController>();

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }
        
        [Fact]
        public void PrivacyTest()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(configure => configure.AddConsole());
            serviceCollection.AddScoped<HomeController>();
            serviceCollection.AddScoped<ILogger<HomeController>, Logger<HomeController>>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var controller = serviceProvider.GetService<HomeController>();

            var result = controller.Privacy();

            Assert.IsType<ViewResult>(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Fact]
        public void ErrorTest()
        {
            var mock = new Mock<HttpContext>();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(configure => configure.AddConsole());
            serviceCollection.AddScoped<HomeController>();
            serviceCollection.AddScoped<ILogger<HomeController>, Logger<HomeController>>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var controller = serviceProvider.GetService<HomeController>();
            
            controller.ControllerContext = new ControllerContext{HttpContext = mock.Object};

            var result = controller.Error();

            Assert.IsType<ViewResult>(result);
        }
    }
}
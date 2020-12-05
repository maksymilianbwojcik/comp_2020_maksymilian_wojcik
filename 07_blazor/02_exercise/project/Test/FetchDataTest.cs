using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Blazor.Data;
using Blazor.Pages;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Testing;
using Moq;
using Xunit;

namespace Test
{
    public class FetchDataTest
    {
        private readonly TestHost _host = new TestHost();
        
        [Fact]
        public void DataFetchingTest()
        {
            var mock = new Mock<IWeatherForecastService>();
            mock.Setup(x => x.GetForecastAsync(It.IsAny<DateTime>())).ReturnsAsync((WeatherForecast[]) null!);
            _host.AddService(mock.Object);
            var component = _host.AddComponent<FetchData>();
            Assert.Contains("Loading...", component.GetMarkup(), StringComparison.Ordinal);
        }
 
        [Fact]
        public void WeatherForecastServiceTest()
        {    
            _host.AddService((IWeatherForecastService) new WeatherForecastService());
            var tbody = _host.AddComponent<FetchData>().Find("tbody");
            Assert.Contains("2020", tbody.InnerHtml, StringComparison.Ordinal);
        }

        
    }
}
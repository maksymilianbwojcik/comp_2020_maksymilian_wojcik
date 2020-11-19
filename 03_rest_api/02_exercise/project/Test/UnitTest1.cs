using System;
using Xunit;
using Utils;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void IsFahrenheitedConvertedRight()
        {
            var weatherForecast = new WeatherForecast();
            weatherForecast.TemperatureC = 0;
            Assert.Equal(32, weatherForecast.TemperatureF);
        }
    }
}
using System;
using Xunit;
using Utils;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void IsFahrenheitConvertedRight()
        {
            var weatherForecast = new WeatherForecast {TemperatureC = 0};
            Assert.Equal(32, weatherForecast.TemperatureF);
        }

        [Fact]
        public void IsDateCorrect()
        {
            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.Today,
                TemperatureC = 100,
            };
            Assert.Equal(DateTime.Today, weatherForecast.Date);
            Assert.Equal(100, weatherForecast.TemperatureC);
            Assert.Equal(211, weatherForecast.TemperatureF);
            Assert.Null(weatherForecast.Summary);

            weatherForecast.Summary = "no kiepsko";
            
            Assert.Equal("no kiepsko", weatherForecast.Summary);
        }
    }
}
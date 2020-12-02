using System;
using System.Threading.Tasks;
using Blazor.Data;
using Blazor.Pages;
using Moq;
using Xunit;

namespace Test
{
    public class FetchDataTest : FetchData
    {
        [Fact]
        public async Task OnInitializedAsyncTest()
        {
            var mock = new Mock<WeatherForecastService>();
            var forecastService = mock.Object;

            var forecasts = await forecastService.GetForecastAsync(DateTime.Now).ConfigureAwait(false);
            
            Assert.Equal(5, forecasts.Length);
        }

        [Fact]
        public void InitialNullForecastsTest()
        {
            var fetch = new FetchData();
            
            Assert.Null(fetch.forecasts);
        }
        
        [Fact]
        public void ForecastsCountCorrectTest()
        {
            var mock = new Mock<WeatherForecastService>();
            var forecastService = mock.Object;
            var forecasts = forecastService.GetForecastAsync(DateTime.Now);
            
            Assert.Equal(5, forecasts.Result.Length);
        }

//         [Fact]
//         public void HopefullyWorksThoughtsAndPrayersTest()
//         {
//             var fetcher = new FetchData();
//             OnInitializedAsync();
//             Assert.Equal(5, fetcher.forecasts.Length);
//         }
    }
}
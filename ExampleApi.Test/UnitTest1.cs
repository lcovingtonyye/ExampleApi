

using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace ExampleApi.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            // Arrange
            using var app = new WebApplicationFactory<Program>(); 
            var client = app.CreateClient(); // can pass in delegate handlers etc to configure the client (like set headers for auth etc)

            // Act
            var weather = await client.GetFromJsonAsync<WeatherForecast>("/WeatherForecast");

            // Assert
            Assert.IsNotNull(weather);
            Assert.IsTrue(weather.TemperatureC == 50);
            Assert.IsTrue(weather.Summary == "Scorching");
        }
    }
}
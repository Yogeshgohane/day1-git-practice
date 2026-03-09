using Xunit;
using Moq;
using MyApp;
using System.Collections.Generic;

namespace MyApp.Tests;

public class WeatherServiceTests
{
    [Fact]
    public void GetWeather_ReturnsExpectedResult()
    {
        var mock = new Mock<IWeatherService>();

        mock.Setup(x => x.GetTemperature(It.IsAny<string>()))
            .Returns(new List<double> { 30, 32, 28, 31, 29 });

        var result = mock.Object.GetTemperature("Pune");

        Assert.Equal(5, result.Count);
    }
}
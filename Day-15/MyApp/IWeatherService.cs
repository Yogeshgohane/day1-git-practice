using System.Collections.Generic;

namespace MyApp;

public interface IWeatherService
{
    List<double> GetTemperature(string city);
}
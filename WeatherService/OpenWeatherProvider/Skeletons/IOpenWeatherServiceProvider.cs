using System;
using System.Collections.Generic;
using System.Text;
using WebHandler.Interface;

namespace WeatherService.OpenWeatherProvider.Skeletons
{
    public interface IOpenWeatherServiceProvider
    {
        string ForcastWeatherByCity(string city, string format);
        IBodyProvider GetWeather();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherService.OpenWeatherProvider.Skeletons
{
    public interface IOpenWeatherApiKeyProvider
    {
        string GetKey();
    }
}

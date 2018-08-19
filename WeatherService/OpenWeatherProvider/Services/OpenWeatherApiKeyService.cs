using System;
using System.Collections.Generic;
using System.Text;
using WeatherService.OpenWeatherProvider.Skeletons;

namespace WeatherService.OpenWeatherProvider.Services
{
    /// <summary>
    /// Service to provide the API Key
    /// </summary>
    public class OpenWeatherApiKeyService : IOpenWeatherApiKeyProvider
    {
        const string KEY = "246f355cb15be9063138812ffcaa523c";
        public string GetKey() => KEY;
    }
}

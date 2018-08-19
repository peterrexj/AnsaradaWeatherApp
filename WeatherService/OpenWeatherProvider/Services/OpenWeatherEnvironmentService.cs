using System;
using System.Collections.Generic;
using System.Text;
using WeatherService.OpenWeatherProvider.Skeletons;

namespace WeatherService.OpenWeatherProvider.Services
{
    /// <summary>
    /// Service to provide the Environment
    /// </summary>
    public class OpenWeatherEnvironmentService : IOpenWeatherEnvironmentProvider
    {
        const string ENV = "http://api.openweathermap.org";
        public string GetEnvironment() => ENV;
    }
}

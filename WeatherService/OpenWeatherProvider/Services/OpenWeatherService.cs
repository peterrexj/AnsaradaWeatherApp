using System;
using System.Collections.Generic;
using System.Text;
using WeatherService.OpenWeatherProvider.Skeletons;
using WebHandler.Interface;
using WebHandler.Services;

namespace WeatherService.OpenWeatherProvider.Services
{
    public class OpenWeatherService : IOpenWeatherServiceProvider
    {
        string _environment;
        IOpenWeatherQueryBuilderProvider _queryBuilderProvider;

        public OpenWeatherService(IOpenWeatherEnvironmentProvider environmentProvider, IOpenWeatherQueryBuilderProvider queryBuilderProvider)
        {
            _environment = environmentProvider.GetEnvironment();
            _queryBuilderProvider = queryBuilderProvider;
        }

        /// <summary>
        /// Gets the Raw Weather data from the API
        /// </summary>
        /// <returns></returns>
        public IBodyProvider GetWeather()
        {
            return new HttpService()
                .SetEnvironment(_environment)
                .PrepareRequest(_queryBuilderProvider.GetWebQuery())
                .Get()
                .ResponseBody;
        }

        /// <summary>
        /// Get Forecast of the weather based on the City and the format requested
        /// </summary>
        /// <param name="city">Weather of the city</param>
        /// <param name="format">Formats: json or xml</param>
        /// <returns></returns>
        public string ForcastWeatherByCity(string city, string format)
        {
            switch (format)
            {
                case "json":
                    _queryBuilderProvider.AsJson = true;
                    break;
                case "xml":
                    _queryBuilderProvider.AsXml = true;
                    break;
                default:
                    throw new ArgumentException("The response format should be either 'json' or 'xml'");
            }
            _queryBuilderProvider.City = city;
            _queryBuilderProvider.Forcast = true;

            return GetWeather().StringContent;
        }
    }
}

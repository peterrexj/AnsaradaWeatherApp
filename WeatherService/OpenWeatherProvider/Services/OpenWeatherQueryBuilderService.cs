using CoreHandler.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherService.OpenWeatherProvider.Skeletons;

namespace WeatherService.OpenWeatherProvider.Services
{
    public class OpenWeatherQueryBuilderService : IOpenWeatherQueryBuilderProvider
    {
        public string City { get; set; }
        public bool AsJson { get; set; }
        public bool AsXml { get; set; }
        public bool AsHtml { get; set; }
        public bool Forcast { get; set; }

        string _key;
        string _contactString(string query) => query.Contains("?") ? "&" : "?";
        public OpenWeatherQueryBuilderService(IOpenWeatherApiKeyProvider openWeatherApiKey)
        {
            _key = openWeatherApiKey.GetKey();
        }

        /// <summary>
        /// Build to the API query with the required parameters
        /// </summary>
        /// <returns></returns>
        public string GetWebQuery()
        {
            string query = "/data/2.5";

            if (Forcast)
            {
                query = $"{query}/forecast";
            }
            if (City.HasValue())
            {
                query = $"{query}{_contactString(query)}q={City}";
            }
            if (AsXml)
            {
                query = $"{query}{_contactString(query)}mode=xml";
            }
            if (AsHtml)
            {
                query = $"{query}{_contactString(query)}mode=html";
            }
            query = $"{query}{_contactString(query)}APPID={_key}";

            return query;
        }
    }
}

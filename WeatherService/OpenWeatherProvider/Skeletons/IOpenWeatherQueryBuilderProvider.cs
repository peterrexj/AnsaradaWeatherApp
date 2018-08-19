using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherService.OpenWeatherProvider.Skeletons
{
    public interface IOpenWeatherQueryBuilderProvider
    {
        string City { get; set; }
        bool AsJson { get; set; }
        bool AsXml { get; set; }
        bool AsHtml { get; set; }
        bool Forcast { get; set; }
        string GetWebQuery();
    }
}

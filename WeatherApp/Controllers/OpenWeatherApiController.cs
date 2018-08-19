using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherService.OpenWeatherProvider.Skeletons;

namespace WeatherApp.Controllers
{
    [Route("api/[controller]/[action]")]
    public class OpenWeatherController : Controller
    {
        IOpenWeatherServiceProvider openWeather;

        public OpenWeatherController(IOpenWeatherServiceProvider openWeatherService)
        {
            openWeather = openWeatherService;
        }

        [HttpGet("{city}")]
        [ActionName("ForcastByCityAsJson")]
        public string ForcastByCityAsJson(string city)
        {
            return openWeather.ForcastWeatherByCity(city, "json");
        }

        [HttpGet("{city}")]
        [ActionName("ForcastByCityAsXml")]
        public string ForcastByCityAsXml(string city)
        {
            return openWeather.ForcastWeatherByCity(city, "xml");
        }
        [HttpGet]
        public string Get()
        {
            return $@"Current supported format: {Environment.NewLine}
                            /api/openweather/forcastbycityasjson/<city>
                            /api/openweather/forcastbycityasxml/<city>
                ";
        }
    }
}

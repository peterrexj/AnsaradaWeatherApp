﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherService.OpenWeatherProvider.Skeletons
{
    public interface IOpenWeatherEnvironmentProvider
    {
        string GetEnvironment();
    }
}

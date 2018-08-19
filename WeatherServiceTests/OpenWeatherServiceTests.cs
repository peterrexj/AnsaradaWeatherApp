using CoreHandler.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using WeatherService.OpenWeatherProvider;
using WeatherService.OpenWeatherProvider.Services;
using WeatherService.OpenWeatherProvider.Skeletons;
using WebHandler.Services;

namespace WeatherServiceTests
{
    [TestClass]
    public class OpenWeatherServiceTests
    {
        const string _apiSampleKey = "b6907d289e10d714a6e88b30761fae22";

        [TestMethod]
        public void Get_401_With_Wrong_ApiKey()
        {
            var mockApiKey = new Mock<IOpenWeatherApiKeyProvider>();

            mockApiKey
                .Setup(m => m.GetKey())
                .Returns("INVALID_KEY");

            IOpenWeatherEnvironmentProvider openWeatherEnvironmentProvider = new OpenWeatherEnvironmentService();
            IOpenWeatherQueryBuilderProvider openWeatherQueryBuilderProvider = new OpenWeatherQueryBuilderService(mockApiKey.Object);
            IOpenWeatherServiceProvider openWeatherServiceProvider = new OpenWeatherService(openWeatherEnvironmentProvider, openWeatherQueryBuilderProvider);

            var result = openWeatherServiceProvider.ForcastWeatherByCity("Sydney", "xml");
            Assert.IsTrue(result.AsJson()?.cod == "401", "Expected to return 401 while passing invalid API key. The return status code is incorrect.");
            Assert.IsTrue(Convert.ToString(result.AsJson()?.message).Contains("Invalid API key"), "Expected to return 401 while passing invalid API key. The return text message does not contain 'Invalid API key'.");
        }

        [TestMethod]
        public void Support_JSON_XML_Response_Only()
        {
            IOpenWeatherApiKeyProvider openWeatherApiKeyProvider = new OpenWeatherApiKeyService();
            IOpenWeatherEnvironmentProvider openWeatherEnvironmentProvider = new OpenWeatherEnvironmentService();
            IOpenWeatherQueryBuilderProvider openWeatherQueryBuilderProvider = new OpenWeatherQueryBuilderService(openWeatherApiKeyProvider);
            IOpenWeatherServiceProvider openWeatherServiceProvider = new OpenWeatherService(openWeatherEnvironmentProvider, openWeatherQueryBuilderProvider);

            Assert.ThrowsException<ArgumentException>(() => openWeatherServiceProvider.ForcastWeatherByCity("Sydney", "html"), "Weather Service supporting formats other than JSON and XML.");
        }

        [TestMethod]
        public void Get_Sample_Forecast_Xml()
        {
            var mockApiKey = new Mock<IOpenWeatherApiKeyProvider>();
            mockApiKey
                .Setup(m => m.GetKey())
                .Returns(_apiSampleKey);

            var mockEnv = new Mock<IOpenWeatherEnvironmentProvider>();
            mockEnv
                .Setup(e => e.GetEnvironment())
                .Returns("https://samples.openweathermap.org");

            IOpenWeatherQueryBuilderProvider qryBuilder = new OpenWeatherQueryBuilderService(mockApiKey.Object)
            {
                AsXml = true,
                Forcast = true,
                City = "London"
            };

            IOpenWeatherServiceProvider openWeatherServiceProvider = new OpenWeatherService(mockEnv.Object, qryBuilder);
            var resp = openWeatherServiceProvider.GetWeather();
            Assert.IsTrue(resp.FilterByXpathAndGetInnerText("//weatherdata/location/name").EqualsIgnoreCase("London"), "The sample response did not resolve and return the expected data.");
        }

        [TestMethod]
        public void Get_Live_Forecast_Xml()
        {
            IOpenWeatherApiKeyProvider openWeatherApiKeyProvider = new OpenWeatherApiKeyService();
            IOpenWeatherEnvironmentProvider openWeatherEnvironmentProvider = new OpenWeatherEnvironmentService();
            IOpenWeatherQueryBuilderProvider openWeatherQueryBuilderProvider = new OpenWeatherQueryBuilderService(openWeatherApiKeyProvider);
            IOpenWeatherServiceProvider openWeatherServiceProvider = new OpenWeatherService(openWeatherEnvironmentProvider, openWeatherQueryBuilderProvider);

            var respResult = openWeatherServiceProvider.ForcastWeatherByCity("Sydney", "xml");

            var content = new BodyProvider(respResult);
            Assert.IsTrue(content.FilterByXpathAndGetInnerText("//weatherdata/location/name").EqualsIgnoreCase("Sydney"), "The sample response did not resolve and return the expected data.");
            var temperatures = content.FilterByXpathGetAll("//weatherdata/forecast/time/temperature", "value");
            Assert.IsTrue(temperatures.Count() > 0, "Temperature data is missing from the Weather Information result");
            Assert.IsTrue(temperatures.Select(t => t.AsDouble()).Any(), "The temperature data received is not in the correct format");
        }
    }
}

# AnsaradaWeatherApp
Test Exercise

This is testing excerise for Ansarada to access the project on OpenWeather API. The project is build over .NET CORE 2.0 and Visual Studio 2017. 
There are five components in the solution
- Core Layer which has the core functionality that is accessed across all the projects like, extensions and helpers
- Web Handler which is a complete helper to the Web Access or API access, this layer encapsulates the background communication and wraps the protocols and other network information. This layer is completely independent on the 3rd party API.
- Weather Service - A service provider layer for different API, current implementation is for OpenWeather API. Each component is seperated and implemented in a way test easily.
- WeatherApp - WebAPI controller provider or a wrapper to the 3rd party API which can be hosted and consumed
- Tests - All core layers are interface implemented and used as dependency injection pattern and helps in unit testing each individual component in detail.

The scope for implementing Unit tests are very high in each component and not defined not but left with a place holder.

Connected with Travis-CI.
SonarCloud not connected which requires more time.

Total time for the solution implementation: Close to ~7 hours including all layers.

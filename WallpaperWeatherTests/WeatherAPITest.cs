using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WallpaperWeather;

namespace WallpaperWeatherTests
{
    [TestClass]
    public class WeatherAPITest
    {
        //integrationstest, benötigt korrekt eingerichte openweathermap api
        [TestMethod]
        public void TestInit()
        {
            SettingsLoader.LoadSettingsFromDisk();
            PersistentData currentData = SettingsLoader.GetCurrentSettingsData();

            WeatherHandler weather = new WeatherHandler(currentData.openWeatherMapAPIKey, currentData.plz);
            WeatherData data = weather.GetCurrentWeatherData();
            Assert.IsNotNull(data, "Weather Data is null");
        }
    }
}

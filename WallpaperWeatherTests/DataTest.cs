using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WallpaperWeather;

namespace WallpaperWeatherTests
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void TestInit()
        {
            WeatherData wd = new WeatherData();

            Assert.IsNotNull(wd, "Weather Data object is null");
            Assert.IsNotNull(wd.data, "Weather Data object is null");
            Assert.IsNotNull(wd.data.clouds, "Weather Data object is null");
            Assert.IsNotNull(wd.data.sys, "Weather Data object is null");
            Assert.IsNotNull(wd.data.wind, "Weather Data object is null");
            Assert.IsNotNull(wd.data.main, "Weather Data object is null");
            Assert.IsNotNull(wd.data.coord, "Weather Data object is null");
            Assert.IsNotNull(wd.data.weather, "Weather Data object is null");
            Assert.IsNotNull(wd.data.weather[0], "Weather Data object is null");
        }
    }
}

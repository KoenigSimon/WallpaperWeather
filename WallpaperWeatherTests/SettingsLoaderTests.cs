using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WallpaperWeather;

namespace WallpaperWeatherTests
{
    [TestClass]
    public class SettingsLoaderTests
    {
        [TestMethod]
        public void TestInitializing()
        {
            PersistentData data = SettingsLoader.GetCurrentData();
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void TestLoading()
        {
            PersistentData data = SettingsLoader.GetCurrentData();
            SettingsLoader.LoadSettings();
            PersistentData data2 = SettingsLoader.GetCurrentData();

            Assert.AreNotEqual(data, data2);
        }
    }
}

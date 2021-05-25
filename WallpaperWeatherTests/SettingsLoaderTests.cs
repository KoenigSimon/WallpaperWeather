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
            PersistentData data = SettingsLoader.GetCurrentSettingsData();
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void TestLoading()
        {
            PersistentData data = SettingsLoader.GetCurrentSettingsData();
            SettingsLoader.LoadSettingsFromDisk();
            PersistentData data2 = SettingsLoader.GetCurrentSettingsData();

            Assert.AreNotEqual(data, data2);
        }
    }
}

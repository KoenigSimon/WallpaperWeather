using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WallpaperWeather;

namespace WallpaperWeatherTests
{
    [TestClass]
    public class PersistentDataTest
    {
        [TestMethod]
        public void PersistantInitTest()
        {
            PersistentData data = new PersistentData();
            Assert.IsNotNull(data);
            Assert.IsNotNull(data.imageData);
            Assert.AreEqual(data.timeZone, "");
            Assert.AreEqual(data.plz, "");
            Assert.AreEqual(data.maxImageCount, 0);
            Assert.IsNull(data.startWithWindows);
            Assert.IsNull(data.changeInBackground);
            Assert.IsNull(data.autoImageSearch);
            Assert.AreEqual(data.openWeatherMapAPIKey, "");
        }

        [TestMethod]
        public void PersistantDefaultTest()
        {
            PersistentData data = new PersistentData();
            data.InitializeToDefaultValues();

            Assert.IsNotNull(data);
            Assert.IsNotNull(data.imageData);
            Assert.AreEqual(data.timeZone, "");
            Assert.AreEqual(data.plz, "");
            Assert.AreEqual(data.maxImageCount, 80);
            Assert.AreEqual(data.startWithWindows, false);
            Assert.AreEqual(data.changeInBackground, false);
            Assert.AreEqual(data.autoImageSearch, false);
            Assert.AreEqual(data.openWeatherMapAPIKey, "");
        }

        [TestMethod]
        public void PersistantCopyTest()
        {
            PersistentData data = new PersistentData();
            data.InitializeToDefaultValues();
            PersistentData data2 = new PersistentData(data);            

            Assert.AreEqual(data.imageData.Count, data2.imageData.Count);
            Assert.AreEqual(data.timeZone, data2.timeZone);
            Assert.AreEqual(data.plz, data2.plz);
            Assert.AreEqual(data.maxImageCount, data2.maxImageCount);
            Assert.AreEqual(data.startWithWindows, data2.startWithWindows);
            Assert.AreEqual(data.changeInBackground, data2.changeInBackground);
            Assert.AreEqual(data.autoImageSearch, data2.autoImageSearch);
            Assert.AreEqual(data.openWeatherMapAPIKey, data2.openWeatherMapAPIKey);

        }
    }
}

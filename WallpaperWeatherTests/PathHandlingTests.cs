using Microsoft.VisualStudio.TestTools.UnitTesting;
using WallpaperWeather;
using System.IO;
using System;

namespace WallpaperWeatherTests
{
    [TestClass]
    public class PathHandlingTests
    {
        //integrationstest, testet integration in das betriebssystem
        [TestMethod]
        public void TestGetCachePath()
        {
            string path = PathHandling.GetCachePath();
            Assert.IsNotNull(path, "Cache Path is null");
            Assert.IsTrue(path.Contains("C:\\"), "Cache path is not on C");
            Assert.IsTrue(path.Contains("WallpaperWeather\\Cache"), "Cache path final folder is wrong");
        }

        [TestMethod]
        public void TestGetSettingsPath()
        {
            string path = PathHandling.GetSettingsPath();
            Assert.IsNotNull(path, "Settings path is null");
            Assert.IsTrue(PathHandling.CheckIfFileExists(path), "File existance check failed");
            Assert.IsTrue(path.Contains(".json"), "File is not a json file");
        }

        [TestMethod]
        public void TestDeleteFile()
        {
            string root = PathHandling.GetCachePath();
            string file = Path.Combine(root, "testfile.png");
            FileStream f = File.Create(file);
            f.Close();

            Assert.IsTrue(File.Exists(file), "Test Method failed");
            PathHandling.DeleteFile(file);
            Assert.IsFalse(File.Exists(file), "File delete failed");
        }
    }
}

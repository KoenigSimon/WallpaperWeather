using Microsoft.VisualStudio.TestTools.UnitTesting;
using WallpaperWeather;

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
            Assert.IsTrue(path.Contains("WallpaperWeather/Cache"), "Cache path final folder is wrong");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallpaperWeather
{
    public class PersistentData
    {
        public PersistentData()
        {
            InitializeEmpty();
        }

        public PersistentData(PersistentData toClone)
        {
            imageData = new List<DataStructures.ImageData>(toClone.imageData);
            timeZone = toClone.timeZone;
            plz = toClone.plz;
            maxImageCount = toClone.maxImageCount;
            startWithWindows = toClone.startWithWindows;
            changeInBackground = toClone.changeInBackground;
            autoImageSearch = toClone.autoImageSearch;
            openWeatherMapAPIKey = toClone.openWeatherMapAPIKey;
        }

        public List<DataStructures.ImageData> imageData { get; set; }
        public string timeZone { get; set; }
        public string plz { get; set; }
        public int maxImageCount { get; set; }
        public bool? startWithWindows { get; set; }
        public bool? changeInBackground { get; set; }
        public bool? autoImageSearch { get; set; }
        public string openWeatherMapAPIKey { get; set; }

        public void InitializeToDefaultValues()
        {
            imageData = new List<DataStructures.ImageData>();
            timeZone = "";
            plz = "";
            maxImageCount = 80;
            startWithWindows = false;
            changeInBackground = false;
            autoImageSearch = false;
            openWeatherMapAPIKey = "";
        }

        public void InitializeEmpty()
        {
            imageData = new List<DataStructures.ImageData>();
            timeZone = "";
            plz = "";
            maxImageCount = 0;
            startWithWindows = null;
            changeInBackground = null;
            autoImageSearch = null;
            openWeatherMapAPIKey = "";
        }

    }
}

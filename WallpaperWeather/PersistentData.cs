using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallpaperWeather
{
    public class PersistentData
    {
        public PersistentData()
        {
        }

        public List<DataStructures.ImageData> imageData { get; set; }
        public string timeZone { get; set; }
        public string plz { get; set; }
        public int maxImageCount { get; set; }
        public bool startWithWindows { get; set; }
        public bool changeInBackground { get; set; }
        public bool autoImageSearch { get; set; }

        public void InitializeToDefaultValues()
        {
            imageData = new List<DataStructures.ImageData>();
            timeZone = "";
            plz = "";
            maxImageCount = 80;
            startWithWindows = false;
            changeInBackground = false;
            autoImageSearch = false;
        }
    }
}

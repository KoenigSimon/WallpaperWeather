using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WallpaperWeather
{    
    static class PathHandling
    {
        public static string GetCachePath()
        {
            string resPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string specificFolder = Path.Combine(resPath, "WallpaperWeather/Cache/");
            Directory.CreateDirectory(specificFolder);
            return specificFolder;
        }

        public static string GetSettingsPath()
        {
            string resPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string file = Path.Combine(resPath, "WallpaperWeather/settings.json");
            return file;
        }

        public static bool CheckIfFileExists(string filePath)
        {
            bool success = File.Exists(filePath);           
            return success;
        }
    }    
}

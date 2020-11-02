using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using Microsoft.Win32;


namespace WallpaperWeather
{
    static class SettingsLoader
    {
        static bool dataLoaded = false;
        static PersistentData data = new PersistentData();
        public static PersistentData changedData = new PersistentData();

        public static void LoadSettings()
        {
            data = new PersistentData();
            string path = PathHandling.GetSettingsPath();

            //if file does not exist, create with default settings
            if (!PathHandling.CheckIfFileExists(path))
            {
                FileStream stream = File.Create(path);
                stream.Close();
                data.InitializeToDefaultValues();
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string jsonString = JsonSerializer.Serialize(data, options);
                File.WriteAllText(path, jsonString);
            }
            else
            {
                //file does exist, read file
                string jsonString = File.ReadAllText(path);
                data = JsonSerializer.Deserialize<PersistentData>(jsonString);
            }
            dataLoaded = true;
        }

        public static void UpdateSettings()
        {
            if (!dataLoaded) return;

            if(changedData.imageData.Count != 0)
            {
                data.imageData = changedData.imageData;
            }
            if(changedData.timeZone != "")
            {
                data.timeZone = changedData.timeZone;
            }
            if(changedData.plz != "")
            {
                data.plz = changedData.plz;
            }
            if(changedData.maxImageCount != 0)
            {
                data.maxImageCount = changedData.maxImageCount;
            }
            if(changedData.startWithWindows != null)
            {
                data.startWithWindows = changedData.startWithWindows;
            }
            if(changedData.changeInBackground != null)
            {
                data.changeInBackground = changedData.changeInBackground;
            }
            if(changedData.autoImageSearch != null)
            {
                data.autoImageSearch = changedData.autoImageSearch;
            }
            if(changedData.openWeatherMapAPIKey != "")
            {
                data.openWeatherMapAPIKey = changedData.openWeatherMapAPIKey;
            }

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(data, options);
            File.WriteAllText(PathHandling.GetSettingsPath(), jsonString);
        }

        public static PersistentData GetCurrentData()
        {
            string path = PathHandling.GetSettingsPath();
            if (PathHandling.CheckIfFileExists(path))
            {
                string jsonString = File.ReadAllText(path);
                data = JsonSerializer.Deserialize<PersistentData>(jsonString);
                return data;
            }
            else
            {
                return null;
            }

            
        }

        public static void ApplyAutoStart()
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if ((bool)data.startWithWindows)
            {                
                rkApp.SetValue("WallpaperWeather", System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
            else
            {
                rkApp.DeleteValue("WallpaperWeather", false);
            }
        }
    }
}

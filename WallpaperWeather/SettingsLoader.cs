using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace WallpaperWeather
{
    static class SettingsLoader
    {
        static bool dataLoaded = false;
        static PersistentData data;

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

        public static void UpdateSettings(PersistentData updatedData)
        {
            if (!dataLoaded) return;

            string jsonString;
            jsonString = JsonSerializer.Serialize(updatedData);
            File.WriteAllText(PathHandling.GetSettingsPath(), jsonString);
        }
    }
}

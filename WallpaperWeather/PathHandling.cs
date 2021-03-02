using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace WallpaperWeather
{    
    static class PathHandling
    {
        public static string GetCachePath()
        {
            string resPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string specificFolder = Path.Combine(resPath, "WallpaperWeather\\Cache\\");
            Directory.CreateDirectory(specificFolder);
            return specificFolder;
        }

        public static string GetSettingsPath()
        {
            string resPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string file = Path.Combine(resPath, "WallpaperWeather\\settings.json");
            return file;
        }

        public static bool CheckIfFileExists(string filePath)
        {
            bool success = File.Exists(filePath);           
            return success;
        }

        public static void ImportFiles()
        {
            string[] files = OpenFileDialog();
            string targetPath = GetCachePath();

            for (int i = 0; i < files.Length; i++)
            {
                string filename = Path.GetFileName(files[i]);
                File.Copy(files[i], Path.Combine(targetPath, filename), true);
            }
        }

        private static string[] OpenFileDialog()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;
                openFileDialog.Title = "Image Browser";

                // Set the file dialog to filter for graphics files.
                openFileDialog.Filter =
                    "Images (*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|" +
                    "All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileNames;
                }
            }

            return new string[0];
        }

        public static void DeleteFile(string name)
        {
            File.Delete(name);
        }

        public static string GetCorrespondingIconPath(DataStructures.enumWeather weather, bool beforeDusk)
        {
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;

            if(beforeDusk)
            {
                switch (weather)
                {
                    case DataStructures.enumWeather.CLEAR_SKY:
                        return string.Format("{0}Resources\\sun.png", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
                    case DataStructures.enumWeather.FEW_CLOUDS:
                        return string.Format("{0}Resources\\sunnyclouds.png", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
                    case DataStructures.enumWeather.SCATTERED_CLOUDS:
                        return string.Format("{0}Resources\\cloudy.png", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
                    case DataStructures.enumWeather.SHOWER_RAIN:
                        return string.Format("{0}Resources\\rain.png", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
                    case DataStructures.enumWeather.THUNDERSTORM:
                        return string.Format("{0}Resources\\thunderstorm.png", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
                }
            }
            else
            {
                switch (weather)
                {
                    case DataStructures.enumWeather.CLEAR_SKY:
                        return string.Format("{0}Resources\\moon.png", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
                    case DataStructures.enumWeather.FEW_CLOUDS:
                        return string.Format("{0}Resources\\nightclouds.png", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
                    case DataStructures.enumWeather.SCATTERED_CLOUDS:
                        return string.Format("{0}Resources\\cloudy.png", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
                    case DataStructures.enumWeather.SHOWER_RAIN:
                        return string.Format("{0}Resources\\rain.png", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
                    case DataStructures.enumWeather.THUNDERSTORM:
                        return string.Format("{0}Resources\\thunderstorm.png", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
                }
            }
            

            return "";
        }
    }    
}

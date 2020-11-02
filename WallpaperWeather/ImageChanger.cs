using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace WallpaperWeather
{
    class ImageChanger
    {
        static WeatherHandler weatherHandler;

        public static void StartImageCycling(WeatherHandler weather)
        {
            weatherHandler = weather;
            Thread updatingThread = new Thread(new ThreadStart(ThreadRun));
            updatingThread.Start();
        }

        private static void ThreadRun()
        {
            try
            {
                while (true)
                {
                    WeatherData currentWeather = weatherHandler.GetCurrentWeatherData();
                    DateTime now = DateTime.Now;
                    PersistentData currentSettings = SettingsLoader.GetCurrentData();

                    //check if transition allowed
                    if((bool)currentSettings.changeInBackground)
                    {
                        if(!AppFocus.OtherAppIsInFullScreen())
                        {
                            Wait();
                            continue;
                        }
                    }

                    DataStructures.ImageData[] images = currentSettings.imageData.ToArray();

                    DataStructures.enumDayTime targetDayTime = Helperfunctions.ConvertTimeToDayTime(now, currentWeather);
                    DataStructures.enumSeason targetSeason = Helperfunctions.ConvertDateToEnumSeason(now);
                    DataStructures.enumWeather targetWeather = Helperfunctions.ConvertOWMDescrToWeather(currentWeather.data.weather[0].description);

                    //filter images to new list after priority
                    //importance desc: season, daytime, weather
                    List<DataStructures.ImageData> filteredImages = new List<DataStructures.ImageData>();
                    for(int ignorance = 0; ignorance <= 3; ignorance++)
                    {
                        for (int i = 0; i < images.Length; i++)
                        {
                            if (images[i].targetSeason == targetSeason)
                            {
                                if (images[i].targetDaytime == targetDayTime)
                                {
                                    if (images[i].targetWeather == targetWeather)
                                    {
                                        if(!images[i].banUse)
                                            filteredImages.Add(images[i]);
                                    }
                                    else if(ignorance > 0)
                                    {
                                        filteredImages.Add(images[i]);
                                    }
                                }
                                else if(ignorance > 1)
                                {
                                    filteredImages.Add(images[i]);
                                }
                            }
                            else if(ignorance > 2)
                            {
                                filteredImages.Add(images[i]);
                            }
                        }
                        if (filteredImages.Count > 0) break;
                    }

                    if (filteredImages.Count == 0)
                    {
                        Wait();
                        continue;
                    }

                    //select random from filtered list
                    Random rnd = new Random();
                    int selected = rnd.Next(0, filteredImages.Count);

                    //change background
                    Uri wallFile = new Uri(filteredImages[selected].fileName);
                    Wallpaper.Set(wallFile, Wallpaper.Style.Stretched);

                    Wait();
                }
            } catch
            {
                return;
            }
        }        

        private static void Wait()
        {
            Thread.Sleep(6000);
        }
    }
}

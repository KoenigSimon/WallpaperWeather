using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;

namespace WallpaperWeather
{
    class WeatherHandler
    {
        private static string _apiKey = "";
        private static string _plz = "";
        private static WeatherData currentWeatherData = new WeatherData();
        private static bool dataReady = false;

        public WeatherHandler(string apiKey, string plz)
        {
            _apiKey = apiKey;
            _plz = plz;

            //poll once for starup
            MakePoll();

            Thread updatingThread = new Thread(new ThreadStart(WeatherPoller));
            //updatingThread.Start();
        }

        public WeatherData GetCurrentWeatherData()
        {
            if (dataReady)
                return currentWeatherData;
            else
                return null;
        }

        private static void WeatherPoller()
        {
            try
            {
                while (true)
                {
                    MakePoll();

                    Thread.Sleep(6000);
                }
            } catch
            {
                //threadabortexception thrown
            }            
        }

        private static void MakePoll()
        {
            dataReady = false;
            string getWeatherUrl = "http://api.openweathermap.org/data/2.5/weather?q=@loc@&appid=" + _apiKey;
            getWeatherUrl = getWeatherUrl.Replace("@loc@", _plz);

            WebClient client = new WebClient();
            string data = client.DownloadString(getWeatherUrl);
            currentWeatherData.data = JsonSerializer.Deserialize<WeatherData.Root>(data);
            dataReady = true;
        }
    }
}

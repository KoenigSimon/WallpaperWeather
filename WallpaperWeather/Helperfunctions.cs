using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WallpaperWeather
{
    static class Helperfunctions
    {

        public static DataStructures.enumWeather ConvertOWMDescrToWeather(string WeatherCondition)
        {
            switch (WeatherCondition)
            {
                case "clear sky":
                    return DataStructures.enumWeather.CLEAR_SKY;
                case "few clouds":
                    return DataStructures.enumWeather.FEW_CLOUDS;
                case "scattered clouds":
                    return DataStructures.enumWeather.SCATTERED_CLOUDS;
                case "broken clouds":
                    return DataStructures.enumWeather.SCATTERED_CLOUDS;
                case "shower rain":
                    return DataStructures.enumWeather.SHOWER_RAIN;
                case "rain":
                    return DataStructures.enumWeather.SHOWER_RAIN;
                case "thunderstorm":
                    return DataStructures.enumWeather.THUNDERSTORM;
                case "snow":
                    return DataStructures.enumWeather.SHOWER_RAIN;
                case "mist":
                    return DataStructures.enumWeather.SCATTERED_CLOUDS;

                default: return DataStructures.enumWeather.CLEAR_SKY;
            }
        }
    }
}

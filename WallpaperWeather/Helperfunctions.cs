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
                case "overcast clouds":
                    return DataStructures.enumWeather.SCATTERED_CLOUDS;

                case "shower rain":
                    return DataStructures.enumWeather.SHOWER_RAIN;
                case "light rain":
                    return DataStructures.enumWeather.SHOWER_RAIN;
                case "moderate rain":
                    return DataStructures.enumWeather.SHOWER_RAIN;
                case "heavy intensity rain":
                    return DataStructures.enumWeather.SHOWER_RAIN;
                case "very heavy rain":
                    return DataStructures.enumWeather.SHOWER_RAIN;
                case "extreme rain":
                    return DataStructures.enumWeather.SHOWER_RAIN;
                case "freezing rain":
                    return DataStructures.enumWeather.SHOWER_RAIN;
                case "light intensity shower rain":
                    return DataStructures.enumWeather.SHOWER_RAIN;
                case "heavy intensity shower rain":
                    return DataStructures.enumWeather.SHOWER_RAIN;
                case "	ragged shower rain":
                    return DataStructures.enumWeather.SHOWER_RAIN;

                case "light snow":
                    return DataStructures.enumWeather.SHOWER_RAIN;
                case "Snow":
                    return DataStructures.enumWeather.SHOWER_RAIN;
                case "Heavy snow":
                    return DataStructures.enumWeather.SHOWER_RAIN;
                case "Sleet":
                    return DataStructures.enumWeather.SHOWER_RAIN;
                case "Light shower sleet":
                    return DataStructures.enumWeather.SHOWER_RAIN;
                case "Shower sleet":
                    return DataStructures.enumWeather.SHOWER_RAIN;
                case "Light rain and snow":
                    return DataStructures.enumWeather.SHOWER_RAIN;
                case "Rain and snow":
                    return DataStructures.enumWeather.SHOWER_RAIN;
                case "Light shower snow":
                    return DataStructures.enumWeather.SHOWER_RAIN;
                case "Shower snow":
                    return DataStructures.enumWeather.SHOWER_RAIN;
                case "Heavy shower snow":
                    return DataStructures.enumWeather.SHOWER_RAIN;



                case "thunderstorm with light rain":
                    return DataStructures.enumWeather.THUNDERSTORM;
                case "thunderstorm with rain":
                    return DataStructures.enumWeather.THUNDERSTORM;
                case "thunderstorm with heavy rain":
                    return DataStructures.enumWeather.THUNDERSTORM;
                case "light thunderstorm":
                    return DataStructures.enumWeather.THUNDERSTORM;
                case "thunderstorm":
                    return DataStructures.enumWeather.THUNDERSTORM;
                case "heavy thunderstorm":
                    return DataStructures.enumWeather.THUNDERSTORM;
                case "ragged thunderstorm":
                    return DataStructures.enumWeather.THUNDERSTORM;
                case "thunderstorm with light drizzle":
                    return DataStructures.enumWeather.THUNDERSTORM;
                case "thunderstorm with drizzle":
                    return DataStructures.enumWeather.THUNDERSTORM;
                case "thunderstorm with heavy drizzle":
                    return DataStructures.enumWeather.THUNDERSTORM;



                case "mist":
                    return DataStructures.enumWeather.SCATTERED_CLOUDS;

                default: return DataStructures.enumWeather.SCATTERED_CLOUDS;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

        public static int ConvertWeatherEnumToComboInt(DataStructures.enumWeather weather)
        {
            switch (weather)
            {
                case DataStructures.enumWeather.CLEAR_SKY:
                    return 0;
                case DataStructures.enumWeather.FEW_CLOUDS:
                    return 1;
                case DataStructures.enumWeather.SCATTERED_CLOUDS:
                    return 2;
                case DataStructures.enumWeather.SHOWER_RAIN:
                    return 3;
                case DataStructures.enumWeather.THUNDERSTORM:
                    return 4;
                default:
                    return 0;
            }
        }

        public static int ConvertDayTimeToComboInt(DataStructures.enumDayTime dayTime)
        {
            switch (dayTime)
            {
                case DataStructures.enumDayTime.DAWN:
                    return 0;
                case DataStructures.enumDayTime.DAY:
                    return 1;
                case DataStructures.enumDayTime.DUSK:
                    return 2;
                case DataStructures.enumDayTime.NIGHT:
                    return 3;
                default:
                    return 0;
            }
        }

        public static int ConvertSeasonToComboInt(DataStructures.enumSeason season)
        {
            switch (season)
            {
                case DataStructures.enumSeason.SPRING:
                    return 0;
                case DataStructures.enumSeason.SUMMER:
                    return 1;
                case DataStructures.enumSeason.AUTUMN:
                    return 2;
                case DataStructures.enumSeason.WINTER:
                    return 3;
                default:
                    return 0;
            }
        }

        public static DataStructures.enumDayTime ConvertComboIntToDaytime(int comboInt)
        {
            switch (comboInt)
            {
                case 0:
                    return DataStructures.enumDayTime.DAWN;
                case 1:
                    return DataStructures.enumDayTime.DAY;
                case 2:
                    return DataStructures.enumDayTime.DUSK;
                case 3:
                    return DataStructures.enumDayTime.NIGHT;
                default:
                    return DataStructures.enumDayTime.DAY;
            }
        }

        public static DataStructures.enumSeason ConvertComboIntToSeason(int comboInt)
        {
            switch (comboInt)
            {
                case 0:
                    return DataStructures.enumSeason.SPRING;
                case 1:
                    return DataStructures.enumSeason.SUMMER;
                case 2:
                    return DataStructures.enumSeason.AUTUMN;
                case 3:
                    return DataStructures.enumSeason.WINTER;
                default:
                    return DataStructures.enumSeason.SUMMER;
            }
        }

        public static DataStructures.enumWeather ConvertComboIntToWeather(int comboInt)
        {
            switch (comboInt)
            {
                case 0:
                    return DataStructures.enumWeather.CLEAR_SKY;
                case 1:
                    return DataStructures.enumWeather.FEW_CLOUDS;
                case 2:
                    return DataStructures.enumWeather.SCATTERED_CLOUDS;
                case 3:
                    return DataStructures.enumWeather.SHOWER_RAIN;
                case 4:
                    return DataStructures.enumWeather.THUNDERSTORM;
                default:
                    return DataStructures.enumWeather.CLEAR_SKY;
            }
        }
    }
}

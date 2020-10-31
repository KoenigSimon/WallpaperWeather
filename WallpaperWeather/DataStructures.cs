using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallpaperWeather
{
    public static class DataStructures
    {
        //enums
        public enum enumWeather
        {
            CLEAR_SKY,
            FEW_CLOUDS,
            SCATTERED_CLOUDS,
            SHOWER_RAIN,
            THUNDERSTORM
        }
        public enum enumDayTime
        {
            DAWN,
            DUSK,
            DAY,
            NIGHT
        }
        public enum enumSeason
        {
            SPRING,
            SUMMER,
            AUTUMN,
            WINTER
        }

        public struct ImageData
        {
            public string fileName;
            public enumWeather targetWeather;
            public enumDayTime targetDaytime;
            public enumSeason targetSeason;
            bool banUse;
        }
    }
}

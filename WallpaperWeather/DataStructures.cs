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
            public string fileName { get; set; }
            public enumWeather targetWeather { get; set; }
            public enumDayTime targetDaytime { get; set; }
            public enumSeason targetSeason { get; set; }
            public bool banUse { get; set; }
        }
    }
}

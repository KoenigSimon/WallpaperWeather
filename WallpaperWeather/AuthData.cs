using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallpaperWeather
{
    class AuthData
    {
        private static string apiKey = "{your API Key here}";

        public static string GetOpenWeatherAPIKey()
        {
            return apiKey;
        }
    }
}

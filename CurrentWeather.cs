﻿using System.Text.Json.Serialization;

//https://openweathermap.org/current
//https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={API key}
//https://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lon}&units=imperial&appid={API key}

//wind direction
//http://snowfence.umn.edu/Components/winddirectionanddegrees.htm
//https://www.ncl.ucar.edu/Document/Functions/Contributed/wind_direction.shtml#:~:text=Meteorological%20wind%20direction%20is%20defined,the%20east%20is%2090%20degrees.
//https://uni.edu/storm/Wind%20Direction%20slide.pdf
//https://en.wikipedia.org/wiki/Wind_direction

namespace OpenWeatherMap
{
    internal record class CurrentWeather(
        [property: JsonPropertyName("coord")] coordRecord Coord,
        [property: JsonPropertyName("weather")] List<WeatherRecord> Weather,
        [property: JsonPropertyName("main")] MainRecord Main,
        //Visibility, meter. The maximum value of the visibility is 10 km so 10000 m -- use ushort
        [property: JsonPropertyName("visibility")] ushort Visibility,
        [property: JsonPropertyName("wind")] WindRecord Wind,
        [property: JsonPropertyName("clouds")] CloudsRecord Clouds,
        [property: JsonPropertyName("rain")] RainRecord Rain,
        [property: JsonPropertyName("snow")] RainRecord Snow,
        [property: JsonPropertyName("dt")] long UnixTimeStamp,
        [property: JsonPropertyName("sys")] SunRiseSetUnixStampRecord SunRiseSetUnixStamp,
        [property: JsonPropertyName("name")] string Name);
    

    internal record class coordRecord(float lon, float lat);
    internal record class WeatherRecord(string main, string description, string icon);

    //At the Earth’s surface the air pressure of the atmosphere is usually within the range 980 to 1030 hPa.
    //The hectoPascal is the modern replacement unit for the millibar:
    //one hPa = one millibar = one thousandth of a “bar”
    //Millibar values used in meteorology range from about 100 to 1050. At sea level, standard air pressure in millibars is 1013.2 --- safe to use ushort to represent data
    //In general, a rising barometer means improving weather. In general, a falling barometer means worsening weather
    //https://www.americangeosciences.org/education/k5geosource/content/weather/why-is-the-weather-different-in-high-and-low-pressure-areas#:~:text=As%20air%20leaves%20the%20high,areas%20of%20fair%2C%20settled%20weather.
    //pressure from the api is measured in hPa
    //temp from the api is in degrees F
    //temp_min Minimum temperature at the moment. This is minimal currently observed temperature
    //temp_max Maximum temperature at the moment. This is maximal currently observed temperature
    //humidity in % -- used byte don't think decimail values are reported
    internal record class MainRecord(float temp, float feels_like, float temp_min, float temp_max, ushort pressure, byte humidity, ushort sea_level, ushort grnd_level);
    //Wind speed miles/hour
    //Wind direction, degrees (meteorological)
    //Wind gust miles/hour
    internal record class WindRecord(float speed, float deg, float gust);
    //all is Cloudiness % -- used byte don't think decimail values are reported
    internal record class CloudsRecord(byte all);

    //rain only shows on api when data is there
    //hr1 Rain volume for the last 1 hour, mm. Please note that only mm as units of measurement are available for this parameter
    //hr3 Rain volume for the last 3 hours, mm. Please note that only mm as units of measurement are available for this parameter
    internal record class RainRecord([property: JsonPropertyName("1h")] float hr1, [property: JsonPropertyName("3h")] float hr3 );

    //snow only shows on api when data is there
    //hr1 Snow volume for the last 1 hour, mm. Please note that only mm as units of measurement are available for this parameter
    //hr3 Snow volume for the last 3 hours, mm. Please note that only mm as units of measurement are available for this parameter
    internal record class SnowRecord([property: JsonPropertyName("1h")]  float hr1, [property: JsonPropertyName("3h")] float hr3);

    internal record class SunRiseSetUnixStampRecord(long sunrise, long sunset);
}

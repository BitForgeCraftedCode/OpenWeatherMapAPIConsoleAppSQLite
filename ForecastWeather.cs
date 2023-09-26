﻿using System.Text.Json.Serialization;

namespace OpenWeatherMap
{
    internal record class ForecastWeather(
        [property: JsonPropertyName("list")] List<ForecastRecord> Forecast,
        [property: JsonPropertyName("city")] CityRecord City);

    internal record class ForecastRecord(
        [property: JsonPropertyName("dt")] long TimeDataForecastedUNIX_UTC,
        [property: JsonPropertyName("main")] MainRecord Main,
        [property: JsonPropertyName("weather")] List<WeatherRecord> Weather,
        [property: JsonPropertyName("clouds")] CloudsRecord Clouds,
        [property: JsonPropertyName("wind")] WindRecord Wind,
        [property: JsonPropertyName("visibility")] ushort Visibility,
        [property: JsonPropertyName("pop")] float ProbabilityPrecipitation,
        [property: JsonPropertyName("rain")] ForecastRainRecord Rain,
        [property: JsonPropertyName("snow")] ForecastRainRecord Snow,
        [property: JsonPropertyName("sys")] PartOfDayRecord PartOfDay,
        [property: JsonPropertyName("dt_txt")] string TimeDataForecastedISO_UTC);

    //unlike current weather 1hr not there
    //hr3 Rain volume for the last 3 hours, mm. Please note that only mm as units of measurement are available for this parameter
    internal record class ForecastRainRecord([property: JsonPropertyName("3h")] float hr3);

    //hr3 Snow volume for the last 3 hours, mm. Please note that only mm as units of measurement are available for this parameter
    internal record class ForecastSnowRecord([property: JsonPropertyName("3h")] float hr3);

    //Part of the day (n - night, d - day)
    internal record class PartOfDayRecord(string pod);
    internal record class CityRecord(string name, coordRecord coord, string country, uint population, long sunrise, long sunset);
}

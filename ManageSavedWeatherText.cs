﻿using Spectre.Console;

namespace OpenWeatherMap
{
    internal static class ManageSavedWeatherText
    {
        public static void SaveCurrentWeatherText(string currentWeather)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("SavedCurrentWeather.txt", false))
                {
                    sw.Write(currentWeather);
                }
            }
            catch (Exception e)
            {
                AnsiConsole.WriteException(e);
            }
            
        }

        public static string GetCurrentWeatherText()
        {
            string weatherText = string.Empty;
            try
            {
                using (StreamReader sr = new StreamReader("SavedCurrentWeather.txt"))
                {
                    weatherText = sr.ReadToEnd();
                    return weatherText;
                }
            }
            catch (Exception e)
            {
                AnsiConsole.WriteException(e);
            }
            return weatherText;
           
        }

        public static void SaveCurrentLocationText(string currentLocation)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("SavedCurrentLocation.txt", false))
                {
                    sw.Write(currentLocation);
                }
            }
            catch (Exception e)
            {
                AnsiConsole.WriteException(e);
            }
            
        }

        public static string GetCurrentLocationText()
        {
            string locationText = string.Empty;
            try
            {
                using (StreamReader sr = new StreamReader("SavedCurrentLocation.txt"))
                {
                    locationText = sr.ReadToEnd();
                    return locationText;
                }
            }
            catch (Exception e)
            {
                AnsiConsole.WriteException(e);
            }
            return locationText;
            
        }

        public static void SaveForecastLocationText(string forecastLocation)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("SavedForecastLocation.txt", false))
                {
                    sw.Write(forecastLocation);
                }
            }
            catch (Exception e)
            {
                AnsiConsole.WriteException(e);
            }
        }
        public static string GetForecastLocationText()
        {
            string locationText = string.Empty;
            try
            {
                using (StreamReader sr = new StreamReader("SavedForecastLocation.txt"))
                {
                    locationText = sr.ReadToEnd();
                    return locationText;
                }
            }
            catch (Exception e)
            {
                AnsiConsole.WriteException(e);
            }
            return locationText;
        }
        public static void SaveForecastText(string forecast)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("SavedForecast.txt", false))
                {
                    sw.Write(forecast);
                }
            }
            catch (Exception e)
            {
                AnsiConsole.WriteException(e);
            }
        }
        public static string GetForecastText()
        {
            string forecastText = string.Empty;
            try 
            {
                using (StreamReader sr = new StreamReader("SavedForecast.txt"))
                {
                    forecastText = sr.ReadToEnd();
                    return forecastText;
                }
            }
            catch (Exception e)
            {
                AnsiConsole.WriteException(e);
            }
            return forecastText;
        }
    }
}

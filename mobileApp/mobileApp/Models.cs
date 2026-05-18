using System.Text.Json.Serialization;

namespace MobileApp.Models
{
    public class PlaceWeather
    {
        [JsonPropertyName("place")]
        public Place? Place { get; set; }

        [JsonPropertyName("weather")]
        public Weather? Weather { get; set; }
    }

    public class Place
    {
        [JsonPropertyName("display_name")]
        public string? DisplayName { get; set; }
    }

    public class Weather
    {
        [JsonPropertyName("current")]
        public CurrentWeather? CurrentWeather { get; set; }
    }

    public class CurrentWeather
    {
        [JsonPropertyName("time")]
        public string? Time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public double Temperature { get; set; }

        [JsonPropertyName("weather_code")]
        public int WeatherCode { get; set; }
    }
}

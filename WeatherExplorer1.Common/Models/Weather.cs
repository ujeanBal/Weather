using Newtonsoft.Json;

namespace WeatherExplorer1.Models
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class Weather
    {
        [JsonProperty(PropertyName="name")]
        public string Сity { get; set; }

        [JsonProperty(PropertyName="main.temp")]
        public double Tеmperature { get; set; }

        [JsonProperty(PropertyName = "main.pressure")]
        public double Pressure { get; set; }

        [JsonProperty(PropertyName = "main.humidity")]
        public double Humidity { get; set; }

        [JsonProperty(PropertyName = "main.temp_min")]
        public double TеmperatureMin { get; set; }

        [JsonProperty(PropertyName = "main.temp_max")]
        public double TеmperatureMax { get; set; }

        [JsonProperty(PropertyName = "wind.speed")]
        public double WindSpeed { get; set; }

        public Weather()
        {

        }

    }
}

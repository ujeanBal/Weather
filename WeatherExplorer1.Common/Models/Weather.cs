using System;
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

        public Weather()
        {

        }

    }
}

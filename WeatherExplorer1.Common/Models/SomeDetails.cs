using System;
using Newtonsoft.Json;
using WeatherExplorer1.Models;

namespace WeatherExplorer1.Common.Models
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class SomeDetails
    {
        [JsonProperty(PropertyName = "sys.country")]
        public string Country { get; set; }
        public SomeDetails()
        {
            //Country = "";
        }
    }
}

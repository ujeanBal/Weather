using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WeatherExplorer1.Models;

namespace WeatherExplorer1.Common.Models
{
    public class WeatherExplorer
    {
        public List<Weather> list { get; set; }

        public WeatherExplorer()
        {
            list = new List<Weather>();
        }
    }
}

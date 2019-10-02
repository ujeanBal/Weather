using System.Collections.Generic;
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

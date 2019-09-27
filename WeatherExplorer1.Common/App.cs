using System;
using WeatherExplorer1.Models;
using WeatherExplorer1.Services;

namespace WeatherExplorer1
{
    public class App
    {
        public static void Initialize()
        {
            ServiceLocator.Instance.Register<IDataStore<Weather>, WeatherRestService>();
        }
    }
}

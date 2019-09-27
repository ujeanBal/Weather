using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using WeatherExplorer1.Common.Models;
using WeatherExplorer1.Models;

namespace WeatherExplorer1.Services
{
    public class WeatherRestService : IDataStore<Weather>
    {
        private readonly string _urlGetMultipleService = "data/2.5/group?id=524901,703448,2643743&units=metric";

        private readonly string _urlGetSingleService = "data/2.5/weather?id=";

        private string token = "&appid=e9561d578e178897490e736893c5ad86";

        private readonly string _basicUrl = "http://api.openweathermap.org";

        private HttpClient _client;

        public WeatherRestService()
        {
            _client = new HttpClient();
        }

        public async Task<Weather> GetItemAsync(string id)
        {

            Weather w = null;
            var response = await _client.GetAsync(_basicUrl + _urlGetSingleService + id + token);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                w = JsonConvert.DeserializeObject<Weather>(result);
            }

            return w;
        }

        public async Task<IEnumerable<Weather>> GetItemsAsync()
        {
            IList<Weather> list = null;

            var response = await _client.GetAsync(_basicUrl + "/" + _urlGetMultipleService + token);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<WeatherExplorer>(result).list;
            }
            return list;
        }

    }
}

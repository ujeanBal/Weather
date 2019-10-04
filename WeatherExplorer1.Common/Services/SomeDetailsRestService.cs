using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherExplorer1.Common.Models;

namespace WeatherExplorer1.Common.Services
{
    public class SomeDetailsRestService:IDataStore<SomeDetails>
    {
        private readonly string _urlGetSingleService = "data/2.5/weather?id=";

        private string token = "&appid=e9561d578e178897490e736893c5ad86";

        private readonly string _basicUrl = "http://api.openweathermap.org/";

        private HttpClient _client;

        public SomeDetailsRestService()
        {
            _client = new HttpClient();
        }

        public async Task<SomeDetails> GetItemAsync(string id)
        {

            SomeDetails w = null;
            var response = await _client.GetAsync(_basicUrl + _urlGetSingleService + id + token);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                w = JsonConvert.DeserializeObject<SomeDetails>(result);
            }

            return w;
        }



        public Task<IEnumerable<SomeDetails>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }
    }
}

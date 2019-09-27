using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherExplorer1
{
    public interface IDataStore<T>
    {
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync();
    }
}

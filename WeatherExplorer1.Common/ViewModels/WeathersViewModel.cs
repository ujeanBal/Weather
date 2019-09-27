
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WeatherExplorer1.Models;

namespace WeatherExplorer1.ViewModels
{
    public class WeathersViewModel : BaseViewModel
    {
        public ObservableCollection<Weather> Items { get; set; }
        public Command LoadWeatherCommand { get; set; }
        public WeathersViewModel()
        {
            Title = "Weathers";
            Items = new ObservableCollection<Weather>();
            LoadWeatherCommand = new Command(async () => await ExecuteLoadWeatherCommand());
        }

        private async Task ExecuteLoadWeatherCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync();
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

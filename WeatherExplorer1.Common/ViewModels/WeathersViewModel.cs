
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;
using WeatherExplorer1.Common.Helpers;
using WeatherExplorer1.Common.ViewModels;
using WeatherExplorer1.Models;
using WeatherExplorer1.ViewModel;

namespace WeatherExplorer1.ViewModels
{
    public class WeathersViewModel : BasicViewModel
    {
        public ObservableCollection<Weather> Items { get; set; }

        public Command LoadWeatherCommand { get; set; }

        public Command ItemsSelectedCommand { get; set; }

        private readonly ViewModelLocator _locator;

        public IDataStore<Weather> DataStore;

        public WeathersViewModel(IDataStore<Weather> dataStore)
        {
            DataStore = dataStore;
            _locator = ViewModelLocator.GetInstance();
            Title = "Weathers";
            Items = new ObservableCollection<Weather>();
            LoadWeatherCommand = new Command(async () => await ExecuteLoadWeatherCommand());
            ItemsSelectedCommand = new Command<Weather>((Weather weather) => NavigateToSelected(weather));
        }

        private void NavigateToSelected(Weather selectedweather)
        {
            var navigation = _locator.Resolve<INavigationService>();

            navigation.NavigateTo(ViewModelLocator.DetailPageKey,
                _locator.ResolveWithParam<WeatherDetailViewModel, Weather>
                ("source", selectedweather));
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

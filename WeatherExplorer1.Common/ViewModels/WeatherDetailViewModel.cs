using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using WeatherExplorer1.Common.Helpers;
using WeatherExplorer1.Common.Models;
using WeatherExplorer1.Models;

namespace WeatherExplorer1.Common.ViewModels
{
    public class WeatherDetailViewModel : BasicViewModel
    {
        private Weather _source;

        private SomeDetails info;

        public Command LoadDetailsCommand { get; set; }

        public Command NeedLoadDetailsCommand { get; set; }

        public IDataStore<SomeDetails> DataStore;

        private bool _isDetailsLoaded;

        private bool _needToDetailsLoad;

        public WeatherDetailViewModel(Weather source, IDataStore<SomeDetails> dataStore)
        {
            _source = source;
            info = new SomeDetails();
            DataStore = dataStore;
            Title = "Details";
            LoadDetailsCommand = new Command(async () => await ExecuteLoadDetailsCommand());
            NeedLoadDetailsCommand = new Command(() => ExecuteNeedLoadDetailsCommand());
        }

        private void ExecuteNeedLoadDetailsCommand()
        {
            NeedToDetailsLoad = NeedToDetailsLoad == true ? false : true;
        }

        private async Task ExecuteLoadDetailsCommand()
        {

            Country = (await DataStore.GetItemAsync(_source.Id)).Country;
            if (info != null)
                IsDetailsLoaded = true;
        }

        public bool IsDetailsLoaded
        {
            get
            {
                return _isDetailsLoaded;
            }
            set
            {
                Set(ref _isDetailsLoaded, value);
            }
        }

        public bool NeedToDetailsLoad
        {
            get
            {
                return _needToDetailsLoad;
            }
            set
            {
                if (value == true) LoadDetailsCommand.Execute(null);
                Set(ref _needToDetailsLoad, value);
            }
        }

        public string Country
        {
            get
            {
                return info.Country;
            }
            set
            {
                info.Country = value;
                RaisePropertyChanged("Country");
            }
        }


        public string TownTitle
        {
            get
            {
                return _source.Сity;
            }
            set
            {
                _source.Сity = value;
                RaisePropertyChanged("Title");
            }
        }

        public double WindSpeed
        {
            get
            {
                return _source.WindSpeed;
            }
            set
            {
                _source.WindSpeed = value;
                RaisePropertyChanged("WindSpeed");
            }
        }

        public double Temperature
        {
            get
            {
                return _source.Tеmperature;
            }
            set
            {
                _source.Tеmperature = value;
                RaisePropertyChanged("Tеmperature");
            }
        }

        public double Humidity
        {
            get
            {
                return _source.Humidity;
            }
            set
            {
                _source.Humidity = value;
                RaisePropertyChanged("Humidity");
            }
        }

        public double Pressure
        {
            get
            {
                return _source.Pressure;
            }
            set
            {
                _source.Pressure = value;
                RaisePropertyChanged("Pressure");
            }
        }


        public double TеmperatureMax
        {
            get
            {
                return _source.TеmperatureMax;
            }
            set
            {
                _source.TеmperatureMax = value;
                RaisePropertyChanged("TеmperatureMax");
            }
        }

        public double TеmperatureMin
        {
            get
            {
                return _source.TеmperatureMin;
            }
            set
            {
                _source.TеmperatureMin = value;
                RaisePropertyChanged("TеmperatureMin");
            }
        }
    }
}

using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WeatherExplorer1.Common.Helpers;
using WeatherExplorer1.Common.Models;
using WeatherExplorer1.Models;

namespace WeatherExplorer1.Common.ViewModels
{
    public class WeatherDetailViewModel : BasicViewModel
    {
        private readonly IDataStore<SomeDetails> _dataStore;

        private Weather _source;

        private SomeDetails info;

        private bool _needShow;

        private bool _isDetailsLoaded;

        public Command LoadDetailsCommand { get; set; }

        public Command NeedLoadDetailsCommand { get; set; }

        public WeatherDetailViewModel(Weather source, IDataStore<SomeDetails> dataStore)
        {
            _source = source;
            info = new SomeDetails();
            _dataStore = dataStore;
            Title = "Details";
            LoadDetailsCommand = new Command(async () => await ExecuteLoadDetailsCommand());       
        }

        private async Task ExecuteLoadDetailsCommand()
        {
            if (!IsDetailsLoaded)
            { 
                Country = (await _dataStore.GetItemAsync(_source.Id)).Country;
                if (info != null)
                {
                    IsDetailsLoaded = true;
                }
            }
        }

        public bool NeedShow
        {
            get
            {
                return _needShow;
            }
            set
            {
                Set(ref _needShow, value);
            }
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

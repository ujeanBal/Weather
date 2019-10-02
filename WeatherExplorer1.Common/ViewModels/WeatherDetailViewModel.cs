using System;
using GalaSoft.MvvmLight;
using WeatherExplorer1.Models;

namespace WeatherExplorer1.Common.ViewModels
{
    public class WeatherDetailViewModel : BasicViewModel
    {
        private Weather _source;

        public WeatherDetailViewModel(Weather source)
        {
            _source = source;
            Title = "Details";
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

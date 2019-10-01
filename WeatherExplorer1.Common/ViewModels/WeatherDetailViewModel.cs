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
    }
}

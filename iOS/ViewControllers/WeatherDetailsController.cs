using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Helpers;
using UIKit;
using WeatherExplorer1.Common.ViewModels;
using WeatherExplorer1.Models;

namespace WeatherExplorer1.iOS.ViewControllers
{
    public partial class WeatherDetailsController : UIViewController
    {
        private readonly List<Binding> _bindings; 

        public WeatherDetailViewModel ViewModel;

        public WeatherDetailsController(WeatherDetailViewModel model) : base("WeatherDetailsController", null)
        {
            ViewModel = model;
            _bindings = new List<Binding>();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            _bindings.Add(this.SetBinding(() => ViewModel.TownTitle, () => Town.Text));
            _bindings.Add(this.SetBinding(() => ViewModel.Humidity, () => Humidity.Text));
            _bindings.Add(this.SetBinding(() => ViewModel.Pressure, () => Pressure.Text));
            _bindings.Add(this.SetBinding(() => ViewModel.Temperature, () => Temperature.Text));
            _bindings.Add(this.SetBinding(() => ViewModel.TеmperatureMax, () => MaxTemp.Text));
            _bindings.Add(this.SetBinding(() => ViewModel.TеmperatureMin, () => MinTemp.Text));
            _bindings.Add(this.SetBinding(() => ViewModel.WindSpeed, () => WindSpeed.Text));
        }
    }
}


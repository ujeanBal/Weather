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
        private readonly List<Binding> bindings = new List<Binding>();
        public WeatherDetailViewModel ViewModel;
        public WeatherDetailsController(WeatherDetailViewModel model) : base("WeatherDetailsController", null)
        {
            ViewModel = model;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            bindings.Add(
    this.SetBinding(
      () => ViewModel.TownTitle,
      () => Town.Text));
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}


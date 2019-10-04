using System.Collections.Generic;
using System.ComponentModel;
using GalaSoft.MvvmLight.Helpers;
using UIKit;
using WeatherExplorer1.Common.ViewModels;

namespace WeatherExplorer1.iOS.ViewControllers
{
    public partial class WeatherDetailsController : UIViewController, INotifyPropertyChanged
    {
        private readonly List<Binding> _bindings;

        private InfoView _detailsView;

        public WeatherDetailViewModel ViewModel;

        public WeatherDetailsController(WeatherDetailViewModel model) : base("WeatherDetailsController", null)
        {
            ViewModel = model;
            _bindings = new List<Binding>();
        }

        private bool _needLoad;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool NeedLoad
        {
            get => _needLoad;
            set
            {
                _needLoad = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NeedLoad"));
            }
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
            _bindings.Add(this.SetBinding(() => this.ViewModel.NeedToDetailsLoad, () => this.NeedLoad));
            _bindings.Add(this.SetBinding(() => this.NeedLoad, () => this.SomeDetailsView.Hidden).
                ConvertSourceToTarget((bool arg) => arg == true ? false : true));
            _bindings.Add(this.SetBinding(() => NeedLoad).WhenSourceChanges(NeedToloadChange));
            _bindings.Add(this.SetBinding(() => ViewModel.IsDetailsLoaded).WhenSourceChanges(UpdateDynamicView));

            this.ShowDetails.SetCommand("TouchUpInside", this.ViewModel.NeedLoadDetailsCommand);
        }

        private void UpdateDynamicView()
        {
            _detailsView?.Update(ViewModel);
        }

        private void NeedToloadChange()
        {
            string buttonText;
            if (NeedLoad == true)
            {
                buttonText = "Hide Country";
                _detailsView = InfoView.Create();
                SomeDetailsView.Add(_detailsView);
                _detailsView.Frame = SomeDetailsView.Bounds;
            }
            else
            {
                buttonText = "Show Country";
                if (SomeDetailsView.Subviews.Length > 0)
                    SomeDetailsView.Delete(SomeDetailsView.Subviews[0]);
            }

            ShowDetails.SetTitle(buttonText, UIControlState.Normal);
        }
    }
}


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
            _bindings.Add(this.SetBinding(() => this.ViewModel.IsDetailsLoaded, () => this.NeedLoad));

            _bindings.Add(this.SetBinding(() => this.ViewModel.NeedShow, () => this.SomeDetailsView.Hidden).
                ConvertSourceToTarget((bool arg) => !arg));

            _bindings.Add(this.SetBinding(() => this.ViewModel.NeedShow, () => this.showHideLabel.Text).
               ConvertSourceToTarget((bool arg) => (arg == true ? "Hide Country" : "Show Country")));

            _bindings.Add(this.SetBinding(() => this.ViewModel.NeedShow, () => this.ShowDetails.On, BindingMode.TwoWay));

            _bindings.Add(this.SetBinding(() => NeedLoad).WhenSourceChanges(NeedToloadChange));

            this.ShowDetails.SetCommand("ValueChanged", this.ViewModel.LoadDetailsCommand);
        }

        private void NeedToloadChange()
        {
            if (this.ShowDetails.On)
            {
                _detailsView = InfoView.Create();
                SomeDetailsView.Add(_detailsView);
                _detailsView.Frame = SomeDetailsView.Bounds;
                _detailsView.SetBinding(ViewModel);
            }
            else
            {
                if (SomeDetailsView.Subviews.Length > 0)
                    SomeDetailsView.Delete(SomeDetailsView.Subviews[0]);
            }
        }
    }
}


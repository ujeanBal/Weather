using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CoreGraphics;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Ioc;
using ObjCRuntime;
using UIKit;
using WeatherExplorer1.Common.ViewModel;
using WeatherExplorer1.Models;
using WeatherExplorer1.ViewModels;

namespace WeatherExplorer1.iOS.ViewControllers
{
    public partial class TownsController : UICollectionViewController
    {
        private ObservableCollectionViewSource<Weather, WeatherCell> _source;
        private readonly List<Binding> bindings = new List<Binding>();

        private WeathersViewModel _vm;
        private WeathersViewModel Vm
        {
            get
            {
                if (_vm is null)
                {
                    _vm = Application.Locator.Main;
                }

                return _vm;
            }
        }


        public TownsController(UICollectionViewLayout layout) : base(layout)
        {
        }

        public TownsController(IntPtr p) : base(p)
        {
        }

        public TownsController(WeatherCollectionDataSource dat)
        {
        }

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();

            CollectionView.RegisterNibForCell(UINib.FromName("WeatherCell", null), WeatherCell.Key);
            _source = new WeatherCollectionDataSource(Vm);

            CollectionView.Source = _source;

            _source.DataSource = Vm.Items;

            UIMenuController.SharedMenuController.MenuItems = new UIMenuItem[] {
                new UIMenuItem ("Custom", new Selector ("custom"))
            };

            Vm.LoadWeatherCommand.Execute(null);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
    }
}



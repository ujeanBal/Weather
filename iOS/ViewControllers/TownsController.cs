using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CoreGraphics;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using ObjCRuntime;
using UIKit;
using WeatherExplorer1.Models;
using WeatherExplorer1.ViewModels;

namespace WeatherExplorer1.iOS.ViewControllers
{
    public partial class TownsController : UICollectionViewController
    {
        private ObservableCollectionViewSource<Weather, WeatherCell> _source;

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

            CollectionView.RegisterNibForSupplementaryView(MyCollectionViewCell.Nib,
                UICollectionElementKindSection.Header, MyCollectionViewCell.headerId);
            CollectionView.RegisterNibForCell(WeatherCell.Nib, WeatherCell.Key);

            CollectionView.ContentInset = new UIEdgeInsets(top: 10, left: 10, bottom: 10, right: 10);
            CollectionView.BackgroundColor = UIColor.LightGray;

            _source = new WeatherCollectionDataSource(Vm);
            CollectionView.Source = _source;

            Vm.LoadWeatherCommand.Execute(null);
        }
    }
}



using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

using WeatherExplorer1.ViewModels;

namespace WeatherExplorer1.iOS.ViewControllers
{
    public partial class TownsController : UICollectionViewController
    {

        public TownsController(UICollectionViewLayout layout) : base(layout)
        {
            InitList();
        }

        public TownsController(IntPtr p) : base(p)
        {
        }

        public TownsController()
        {
            InitList();
        }

        private void InitList()
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            WeatherCollectionDataSource dataSource = new WeatherCollectionDataSource(new WeathersViewModel());
            CollectionView.RegisterNibForCell(WeatherCell.Nib, WeatherCell.Key);
            CollectionView.Source = dataSource;

            UIMenuController.SharedMenuController.MenuItems = new UIMenuItem[] {
                new UIMenuItem ("Custom", new Selector ("custom"))
            };

            dataSource.PropertyChanged += DataSource_PropertyChanged;
        }

        private void DataSource_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            CollectionView.ReloadData();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
    }
}



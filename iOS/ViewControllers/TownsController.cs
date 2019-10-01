using System;
using System.Collections.Generic;
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
        private WeathersViewModel Vm
        {
            get
            {
                return Application.Locator.Main;
            }
        }


        public TownsController(UICollectionViewLayout layout) : base(layout)
        {
            InitList();
        }

        public TownsController(IntPtr p) : base(p)
        {
        }

        public TownsController(WeatherCollectionDataSource dat)
        {
            InitList();
        }

        private void InitList()
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
          WeatherCollectionDataSource dataSource = new WeatherCollectionDataSource(Vm);
            _source = Vm.Items.GetCollectionViewSource<Weather, WeatherCell>(
                  BindCell,
                 null,
                  WeatherCell.Key,()=> { return new WeatherCollectionDataSource(Vm); });
            CollectionView.Source = _source;
            //  _source.DataSource
            // Last argument is optional, provides a way to define your own derived class and extend it.

            //    CollectionView.Source = _source;


            //     CollectionView.Source = dataSource;
            //this.SetBinding(
            // () => Vm.Items,
            // () => CollectionView.Source).ConvertSourceToTarget(e => e);

            this.SetBinding(
               () => Vm.Items).WhenSourceChanges(()=>CollectionView.ReloadData());
          // .ConvertSourceToTarget(e => e);

            CollectionView.RegisterNibForCell(WeatherCell.Nib, WeatherCell.Key);
       

            UIMenuController.SharedMenuController.MenuItems = new UIMenuItem[] {
                new UIMenuItem ("Custom", new Selector ("custom"))
            };
        }

        private void BindCell(WeatherCell arg1, Weather arg2, NSIndexPath arg3)
        {
            throw new NotImplementedException();
        }

        private void BindCell(WeatherCell collectionViewCell, Item item, NSIndexPath path)
        {
            //collectionViewCell.Text = item.Id.ToString();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
    }
}



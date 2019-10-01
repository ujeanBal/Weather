using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Autofac;
using CoreGraphics;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using UIKit;
using WeatherExplorer1.Common.ViewModels;
using WeatherExplorer1.Models;
using WeatherExplorer1.ViewModel;
using WeatherExplorer1.ViewModels;

namespace WeatherExplorer1.iOS
{
    public class WeatherCollectionDataSource : ObservableCollectionViewSource<Weather,WeatherCell>
    {
        WeathersViewModel WeathersExplorer;

        public WeatherCollectionDataSource(WeathersViewModel weathersExplorer)
        {
            WeathersExplorer = weathersExplorer;

            WeathersExplorer.LoadWeatherCommand.Execute(null);
        
        }




       

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return WeathersExplorer.Items.Count;
        }

        public override bool ShouldHighlightItem(UICollectionView collectionView, NSIndexPath indexPath)
        {
            return true;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = collectionView.DequeueReusableCell(WeatherCell.Key, indexPath) as WeatherCell;

            cell.PopulateCell(WeathersExplorer.Items[indexPath.Row]);
            return cell;
        }

        [Export("collectionView:layout:sizeForItemAtIndexPath:"), CompilerGenerated]
        public virtual CGSize GetSizeForItem(UICollectionView collectionView,
            UICollectionViewLayout layout, NSIndexPath indexPath)
        {

            nfloat mainWidth = collectionView.Frame.Width;
            nfloat cellWidth = mainWidth;

            nfloat mainHeight = (collectionView.Frame.Height * (nfloat)0.75);
            nfloat cellHeight = mainHeight / 5;

            return new CGSize(cellWidth, cellHeight);
        }


        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var navigation = Application.Locator.Resolve<INavigationService>();
            navigation.NavigateTo(ViewModelLocator.DetailPageKey,
                Application.Locator.ResolveWithParam<WeatherDetailViewModel,Weather>
                ("source", WeathersExplorer.Items[indexPath.Row]));
        }

    }
}

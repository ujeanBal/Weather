using System;
using System.Runtime.CompilerServices;
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
    public class WeatherCollectionDataSource : ObservableCollectionViewSource<Weather, WeatherCell>
    {
        WeathersViewModel WeathersExplorer;

        public WeatherCollectionDataSource(WeathersViewModel weathersExplorer)
        {
            WeathersExplorer = weathersExplorer;
            DataSource = weathersExplorer.Items;
        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            base.NumberOfSections(collectionView);

            return 1;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            base.GetItemsCount(collectionView, section);

            return WeathersExplorer.Items.Count;
        }

        public override bool ShouldHighlightItem(UICollectionView collectionView, NSIndexPath indexPath)
        {
            return true;
        }

        protected override void BindCell(UICollectionViewCell cell, object item, NSIndexPath indexPath)
        {
            (cell as WeatherCell).PopulateCell(item as Weather);
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

            nfloat mainWidth = collectionView.Frame.Width - 20f;
            nfloat cellWidth = mainWidth;

            nfloat mainHeight = (collectionView.Frame.Height * (nfloat)0.30);
            nfloat cellHeight = mainHeight / 5;

            return new CGSize(cellWidth, cellHeight);
        }

        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var navigation = Application.Locator.Resolve<INavigationService>();

            navigation.NavigateTo(ViewModelLocator.DetailPageKey,
                Application.Locator.ResolveWithParam<WeatherDetailViewModel, Weather>
                ("source", WeathersExplorer.Items[indexPath.Row]));
        }

        public override UICollectionReusableView GetViewForSupplementaryElement(UICollectionView collectionView,
            NSString elementKind, NSIndexPath indexPath)
        {
            var headerView = collectionView.DequeueReusableSupplementaryView(elementKind,
                MyCollectionViewCell.headerId, indexPath) as MyCollectionViewCell;
            headerView.PooulateText("Weather now");
            return headerView;
        }
    }
}
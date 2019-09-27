using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CoreGraphics;
using Foundation;
using UIKit;
using WeatherExplorer1.ViewModels;

namespace WeatherExplorer1.iOS
{
    public class WeatherCollectionDataSource : UICollectionViewSource, INotifyPropertyChanged
    {
        WeathersViewModel WeathersExplorer;



        public WeatherCollectionDataSource(WeathersViewModel weathersExplorer)
        {
            WeathersExplorer = weathersExplorer;

            WeathersExplorer.LoadWeatherCommand.Execute(null);
            WeathersExplorer.Items.CollectionChanged += Items_CollectionChanged;
        }

        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("Source");
        }


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

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
        public virtual CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {

            nfloat mainWidth = collectionView.Frame.Width;
            nfloat cellWidth = mainWidth;

            nfloat mainHeight = (collectionView.Frame.Height * (nfloat)0.75);
            nfloat cellHeight = mainHeight / 5;

            return new CGSize(cellWidth, cellHeight);
        }

    }
}

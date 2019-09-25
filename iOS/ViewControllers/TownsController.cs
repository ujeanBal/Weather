using System;
using System.Collections.Generic;
using Foundation;
using ObjCRuntime;
using UIKit;
using WeatherExplorer1.Models;

namespace WeatherExplorer1.iOS.ViewControllers
{
    public partial class TownsController : UICollectionViewController
    {
        List<Weather> listWeather;
        public TownsController(IntPtr handle) : base(handle)
        {
            InitList();
        }
        public TownsController()
        {
            InitList();
        }

        private void InitList()
        {
            listWeather = new List<Weather>();
            listWeather.Add(new Weather() { Сity = "Kharkiv", Tеmperature = 23.5 });
            listWeather.Add(new Weather() { Сity = "Kiev", Tеmperature = 24.5 });
            listWeather.Add(new Weather() { Сity = "Boston", Tеmperature = 25.5 });
            listWeather.Add(new Weather() { Сity = "Urmala", Tеmperature = 26.5 });
            listWeather.Add(new Weather() { Сity = "Moscow", Tеmperature = 27.5 });
            listWeather.Add(new Weather() { Сity = "Lviv", Tеmperature = 28.5 });
            listWeather.Add(new Weather() { Сity = "Praga", Tеmperature = 29.5 });
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return listWeather.Count;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = collectionView.DequeueReusableCell(WeatherCell.Key, indexPath) as WeatherCell;
            if (cell == null)
            {
                cell = new WeatherCell();
                var views = NSBundle.MainBundle.LoadNib(WeatherCell.Key, cell, null);
                cell = Runtime.GetNSObject(views.ValueAt(0)) as WeatherCell;
            }
            cell.PopulateCell(listWeather[indexPath.Row]);
            return cell;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}



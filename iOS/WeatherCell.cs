using System;

using Foundation;
using UIKit;
using WeatherExplorer1.Models;

namespace WeatherExplorer1.iOS
{
    public partial class WeatherCell : UICollectionViewCell
    {
        public static readonly NSString Key = new NSString("WeatherCell");
        public static readonly UINib Nib;

        static WeatherCell()
        {
            Nib = UINib.FromName("WeatherCell", NSBundle.MainBundle);
        }

        public WeatherCell()
        {

        }

        protected WeatherCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        public void PopulateCell(Weather currentWeather)
        {
            Title.Text = currentWeather.Сity;
            Temperature.Text = currentWeather.Tеmperature.ToString();
        }
    }
}

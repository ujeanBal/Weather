using System;
using CoreGraphics;
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

        [Export("initWithFrame:")]
        public WeatherCell(CGRect frame):base(frame)
        {
            BackgroundView = new UIView { BackgroundColor = UIColor.White };
        }

        public WeatherCell(IntPtr ptr) : base(ptr)
        {
            BackgroundView = new UIView { BackgroundColor = UIColor.White };
            Layer.CornerRadius = 30.0F;
        }


        public void PopulateCell(Weather currentWeather)
        {
            Title.Text = currentWeather.Сity;
            Temperature.Text = currentWeather.Tеmperature.ToString();
        }

        public override UICollectionViewLayoutAttributes PreferredLayoutAttributesFittingAttributes(UICollectionViewLayoutAttributes layoutAttributes)
        {
            return base.PreferredLayoutAttributesFittingAttributes(layoutAttributes);
        }
    }
}

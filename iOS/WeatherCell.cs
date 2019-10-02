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

        static WeatherCell()
        {
        }

        [Export("initWithFrame:")]
        public WeatherCell(CGRect frame):base(frame)
        {
        }

        public WeatherCell(IntPtr ptr) : base(ptr)
        {
            BackgroundView = new UIView { BackgroundColor = UIColor.White };
            Layer.CornerRadius = 20.0F;
            // LayoutMargins = new UIEdgeInsets(20, 20, 20, 20);
        }

        public void PopulateCell(Weather currentWeather)
        {
            Title.Text = currentWeather.Сity;
        }

        public override UICollectionViewLayoutAttributes PreferredLayoutAttributesFittingAttributes(
            UICollectionViewLayoutAttributes layoutAttributes)
        {
            return base.PreferredLayoutAttributesFittingAttributes(layoutAttributes);
        }
    }
}

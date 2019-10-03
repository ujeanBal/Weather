using System;
using CoreGraphics;
using Foundation;
using UIKit;
using WeatherExplorer1.Models;

namespace WeatherExplorer1.iOS
{
    public partial class WeatherCell : UICollectionViewCell
    {
        public static readonly NSString Key;

        public static readonly UINib Nib;

        static WeatherCell()
        {
            var name = "WeatherCell";
            Nib = UINib.FromName(name, null);
            Key = new NSString(name);
        }

        [Export("initWithFrame:")]
        public WeatherCell(CGRect frame) : base(frame)
        {
        }

        public WeatherCell(IntPtr ptr) : base(ptr)
        {
            BackgroundView = new UIView { BackgroundColor = UIColor.White };
            Layer.CornerRadius = 20.0F;
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

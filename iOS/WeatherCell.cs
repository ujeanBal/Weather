using System;
using CoreGraphics;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using UIKit;
using WeatherExplorer1.Models;

namespace WeatherExplorer1.iOS
{
    public partial class WeatherCell : UICollectionViewCell
    {
        public static readonly NSString Key;

        private Weather viewModel;
        private Binding binding;

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
            viewModel = currentWeather;
            binding = this.SetBinding(() => viewModel.Сity, () => Title.Text);
            // Title.Text = currentWeather.Сity;
        }

        public override void PrepareForReuse()
        {
            base.PrepareForReuse();
            binding?.Detach();
        }

        public override UICollectionViewLayoutAttributes PreferredLayoutAttributesFittingAttributes(
            UICollectionViewLayoutAttributes layoutAttributes)
        {
            return base.PreferredLayoutAttributesFittingAttributes(layoutAttributes);
        }
    }
}

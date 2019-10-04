using System;
using CoreGraphics;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using ObjCRuntime;
using UIKit;
using WeatherExplorer1.Common.ViewModels;

namespace WeatherExplorer1.iOS
{

    public partial class InfoView : UIView
    {
        public static readonly UINib Nib = UINib.FromName("InfoView", NSBundle.MainBundle);

        public static readonly NSString Key = new NSString("InfoView");

        public InfoView(IntPtr handle) : base(handle)
        {
        }

        public static InfoView Create()
        {
            var array = NSBundle.MainBundle.LoadNib(nameof(InfoView), null, null);
            var view = Runtime.GetNSObject<InfoView>(array.ValueAt(0));

            return view;
        }

        public void Update(WeatherDetailViewModel vm)
        {
            CountryLabel.Text = vm.Country;
        }
    }
}
using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace WeatherExplorer1.iOS
{
    public partial class MyCollectionViewCell : UICollectionReusableView
    {
        public static NSString headerId;

        public static readonly UINib Nib;

        static MyCollectionViewCell() {
            var name = "MyCollectionViewCell";
            Nib = UINib.FromName(name, null);
            headerId = new NSString(name);
        }

        protected MyCollectionViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        [Export("initWithFrame:")]
        public MyCollectionViewCell(CGRect frame) : base(frame)
        {
        }

        public void PooulateText(string header) {
            HeaderLabel.Text = header;
        }
    }
}

// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace WeatherExplorer1.iOS
{
    [Register ("InfoView")]
    partial class InfoView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CountryLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CountryLabel != null) {
                CountryLabel.Dispose ();
                CountryLabel = null;
            }
        }
    }
}
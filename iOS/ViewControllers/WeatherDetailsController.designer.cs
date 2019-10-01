// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace WeatherExplorer1.iOS.ViewControllers
{
    [Register ("WeatherDetailsController")]
    partial class WeatherDetailsController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Temperature { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Town { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Temperature != null) {
                Temperature.Dispose ();
                Temperature = null;
            }

            if (Town != null) {
                Town.Dispose ();
                Town = null;
            }
        }
    }
}
using CoreGraphics;
using Foundation;
using UIKit;
using WeatherExplorer1.iOS.ViewControllers;

namespace WeatherExplorer1.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations
#pragma warning disable 414
        // class-level declarations
        public override UIWindow Window
        {
            get;
            set;
        }
#pragma warning restore 414
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            App.Initialize();
            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            var controller = new TownsController(new UICollectionViewFlowLayout()/*{
                ItemSize = new CGSize((float)UIScreen.MainScreen.Bounds.Size.Width-20, 100.0f),
                HeaderReferenceSize = new CGSize(100, 100),
                SectionInset = new UIEdgeInsets(0,0,0,0),
                ScrollDirection = UICollectionViewScrollDirection.Vertical,
               
                MinimumInteritemSpacing = 10, // minimum spacing between cells
                MinimumLineSpacing = 10 // minimum spacing between rows if ScrollDirection is Vertical or between columns if Horizontal

        }*/);

            var navController = new UINavigationController(controller);

            Window.RootViewController = navController;

            // make the window visible
            Window.MakeKeyAndVisible();

            return true;
        }
    
    }
}

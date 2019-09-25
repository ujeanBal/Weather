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
           Window = new UIWindow(UIScreen.MainScreen.Bounds);

            var controller = new TownsController();
            controller.View.BackgroundColor = UIColor.Cyan;
            var navController = new UINavigationController(controller);

            Window.RootViewController = navController;

            // make the window visible
            Window.MakeKeyAndVisible();

            return true;
        }
    
    }
}

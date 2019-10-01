using CoreGraphics;
using Foundation;
using UIKit;
using WeatherExplorer1.iOS.ViewControllers;
using GalaSoft.MvvmLight.Ioc;
 using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using WeatherExplorer1.ViewModel;

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


            // Configure and register the MVVM Light NavigationService
            var nav = new NavigationService();
           

            var navController = new UINavigationController(new TownsController(new UICollectionViewFlowLayout()));
            Window.RootViewController = navController;

            nav.Initialize((UINavigationController)Window.RootViewController);

            RegisterNavigation(nav);
           

            Window.MakeKeyAndVisible();
            return true;
        }

        private void RegisterNavigation(NavigationService nav) {

            nav.Configure(ViewModelLocator.DetailPageKey,typeof(WeatherDetailsController));
            Application.Locator.Register<INavigationService>(nav);
        }
    
    }
}

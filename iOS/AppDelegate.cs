using Foundation;
using UIKit;
using WeatherExplorer1.iOS.ViewControllers;
using GalaSoft.MvvmLight.Views;
using WeatherExplorer1.ViewModel;

namespace WeatherExplorer1.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            var nav = new NavigationService();

            var navController = new UINavigationController(new TownsController(new UICollectionViewFlowLayout()));
            //  SectionInset= new UIEdgeInsets(10f,10f,10f,10f)}  ));
            Window.RootViewController = navController;

            nav.Initialize((UINavigationController)Window.RootViewController);

            RegisterNavigation(nav);

            Window.MakeKeyAndVisible();
            return true;
        }

        private void RegisterNavigation(NavigationService nav)
        {
            nav.Configure(ViewModelLocator.DetailPageKey, typeof(WeatherDetailsController));
            Application.Locator.Register<INavigationService>(nav);
        }

    }
}

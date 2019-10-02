using UIKit;
using WeatherExplorer1.ViewModel;

namespace WeatherExplorer1.iOS
{
    public class Application
    {
        private static ViewModelLocator locator;

        static void Main(string[] args) => UIApplication.Main(args, null, "AppDelegate");

        public static ViewModelLocator Locator => locator ?? (locator = new ViewModelLocator());
    }
}

/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:WeatherExplorer1.iOS"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using Autofac;

using GalaSoft.MvvmLight.Ioc;
using WeatherExplorer1.Common.ViewModel;
using WeatherExplorer1.Common.ViewModels;
using WeatherExplorer1.Models;
using WeatherExplorer1.Services;
using WeatherExplorer1.ViewModels;

namespace WeatherExplorer1.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
		/// The key used by the NavigationService to go to the second page.
		/// </summary>
		public const string DetailPageKey = "DetailPage";

        private ContainerBuilder builder;

        private readonly IContainer container;

        public ViewModelLocator()
        {
            builder = new ContainerBuilder();

            builder.RegisterInstance(new WeatherRestService())
                .As<IDataStore<Weather>>();

            builder.RegisterType<WeathersViewModel>();

            builder.Register((c, p) =>
                new WeatherDetailViewModel(p.Named<Weather>("source")))
                .As<WeatherDetailViewModel>();

            container = builder.Build();

        }

        public void Register<T>(T instance) where T : class
        {
            var newBuilder = new ContainerBuilder();
            newBuilder.Register<T>(t => instance).As<T>();

            newBuilder.Update(container);
        }

        public T Resolve<T>() where T : class
        {
            return container.Resolve<T>();
        }

        public T ResolveWithParam<T, V>(string nameParam, V valueParam) where T : class
        {
            return container.Resolve<T>(new NamedParameter(nameParam, valueParam));
        }


        public WeathersViewModel Main => container.Resolve<WeathersViewModel>();

    }
}
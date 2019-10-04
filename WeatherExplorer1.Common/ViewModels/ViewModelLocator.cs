using Autofac;
using WeatherExplorer1.Common.Models;
using WeatherExplorer1.Common.Services;
using WeatherExplorer1.Common.ViewModels;
using WeatherExplorer1.Models;
using WeatherExplorer1.Services;
using WeatherExplorer1.ViewModels;

namespace WeatherExplorer1.ViewModel
{

    public class ViewModelLocator
    {
		public const string DetailPageKey = "DetailPage";

        private readonly IContainer container;

        public WeathersViewModel Main => container.Resolve<WeathersViewModel>();

        public ViewModelLocator()
        {
           var builder = new ContainerBuilder();

            builder.RegisterInstance(new WeatherRestService())
                .As<IDataStore<Weather>>();

            builder.RegisterInstance(new SomeDetailsRestService())
             .As<IDataStore<SomeDetails>>();

            builder.RegisterType<WeathersViewModel>();

            builder.Register((c, p) =>
                new WeatherDetailViewModel(p.Named<Weather>("source"),container.Resolve<IDataStore<SomeDetails>>()))
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
    }
}
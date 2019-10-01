using System;
using System.Collections.Generic;

namespace WeatherExplorer1
{
    public sealed class ServiceLocator1
    {
        static readonly Lazy<ServiceLocator1> instance = new Lazy<ServiceLocator1>(() => new ServiceLocator1());
        readonly Dictionary<Type, Lazy<object>> registeredServices = new Dictionary<Type, Lazy<object>>();

        public static ServiceLocator1 Instance => instance.Value;

        public void Register<TContract, TService>() where TService : new()
        {
            registeredServices[typeof(TContract)] =
                new Lazy<object>(() => Activator.CreateInstance(typeof(TService)));
        }

        public T Get<T>() where T : class
        {
            Lazy<object> service;
            if (registeredServices.TryGetValue(typeof(T), out service))
            {
                return (T)service.Value;
            }

            return null;
        }
    }
}

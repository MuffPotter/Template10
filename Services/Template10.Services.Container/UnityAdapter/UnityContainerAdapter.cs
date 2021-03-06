﻿using System;
using Microsoft.Practices.Unity;

namespace Template10.Services.Dependency
{
    public class UnityContainerAdapter : IContainerAdapter
    {
        internal IUnityContainer _container;
        internal UnityContainerAdapter()
        {
            _container = new UnityContainer();
        }

        LifetimeManager _lifetime = new ContainerControlledLifetimeManager();

        public T Resolve<T>()
            where T : class
            => _container.Resolve(typeof(T)) as T;

        public TInterface Resolve<TInterface>(string key)
            where TInterface : class
            => _container.Resolve<TInterface>(key);

        public void Register<TInterface, TClass>()
            where TInterface : class
            where TClass : class, TInterface
            => _container.RegisterType(typeof(TInterface), typeof(TClass), _lifetime);

        public void Register<TInterface>(TInterface instance)
            where TInterface : class
            => _container.RegisterInstance(typeof(TInterface), instance, _lifetime);

        public void Register<TInterface, TClass>(string key)
            where TInterface : class
            where TClass : class, TInterface
            => _container.RegisterType<TInterface, TClass>(key);

        public void RegisterInstance<TClass>(TClass instance)
            where TClass : class
            => _container.RegisterInstance(instance);

        public void RegisterInstance<TInterface, TClass>(TClass instance)
            where TInterface : class
            where TClass : class, TInterface
            => _container.RegisterInstance<TInterface>(instance);
    }
}

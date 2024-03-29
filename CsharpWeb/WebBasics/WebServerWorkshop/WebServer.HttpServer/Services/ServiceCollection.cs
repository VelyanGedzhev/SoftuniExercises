﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace WebServer.Server.Services
{
    public class ServiceCollection : IServiceCollection
    {
        private readonly Dictionary<Type, Type> services;

        public ServiceCollection() 
            => this.services = new();

        public IServiceCollection Add<TService, TImplementation>() 
            where TService : class
            where TImplementation : TService
        {
            this.services[typeof(TService)] = typeof(TImplementation);

            return this;
        }

        public IServiceCollection Add<TService>()
            where TService : class
            => this.Add<TService, TService>();

        public TService Get<TService>()
            where TService : class
        {
            var typeOfService = typeof(TService);

            if (!this.services.ContainsKey(typeOfService))
            {
                return null;
            }

            var implementationType = this.services[typeOfService];

            return (TService)this.CreateInstance(implementationType);
        }

        public object CreateInstance(Type type)
        {
            if (this.services.ContainsKey(type))
            {
                type = this.services[type];
            }

            var constructors = type.GetConstructors();

            if (constructors.Length > 1)
            {
                throw new InvalidOperationException("Multiple constructors are not supported!");
            }

            var constructor = constructors.First();

            var parameteres = constructor.GetParameters();

            var parameterValues = new object[parameteres.Length];

            for (int i = 0; i < parameteres.Length; i++)
            {
                var parameterValue = this.CreateInstance(parameteres[i].ParameterType);

                parameterValues[i] = parameterValue;
            }

            //return Activator.CreateInstance(type, parameterValues);
            return constructor.Invoke(parameterValues);
        }
    }
}

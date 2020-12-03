using DIContainer.Attributes;
using DIContainer.Modules;
using System;
using System.Reflection;

namespace DIContainer.Injectors
{
    public class Injector
    {
        private IModule module;

        public Injector(IModule module)
        {
            this.module = module;
        }

        public TClass Inject<TClass>()
        {
            Type classType = typeof(TClass);
            ConstructorInfo[] constructors = classType.GetConstructors();

            foreach (var ctor in constructors)
            {
                if (ctor.GetCustomAttribute(typeof(Inject)) == null)
                {
                    continue;
                }


                ParameterInfo[] ctorParams = ctor.GetParameters();
                object[] implementationParams = new object[ctorParams.Length];
                int i = 0;

                foreach (var ctorParam in ctorParams)
                {
                    Named namedAttribute = ctorParam.GetCustomAttribute(typeof(Named)) as Named;
                    Type implementationType = module.GetMapping(ctorParam.ParameterType, namedAttribute);


                    if (implementationType == null)
                    {
                        implementationParams[i++] = null;
                    }
                    else
                    {
                        implementationParams[i++] = Activator.CreateInstance(implementationType);
                    }
                }

                return (TClass)Activator.CreateInstance(classType, implementationParams);
            }

            return default(TClass);
        }
    }
}

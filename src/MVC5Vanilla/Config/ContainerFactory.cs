using System;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using FluentValidation;
using MVC5Vanilla.Config.Custom;
using MVC5Vanilla.Config.Standard;


namespace MVC5Vanilla.Config
{
    public class ContainerFactory
    {
        public IContainer Create(Action<IContainer> resolve)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            var builder = new ContainerBuilder();

            builder.RegisterFilterProvider();
            builder.RegisterControllers(currentAssembly);
            builder.RegisterType<JsonNetActionInvoker>().As<IActionInvoker>();

            builder.RegisterModule<StandardModule>();
            builder.RegisterModule<CustomModule>();

            builder.RegisterType<ThingFinder>().AsSelf();

            var findValidatorsInAssembly = AssemblyScanner.FindValidatorsInAssembly(currentAssembly);
            foreach (var item in findValidatorsInAssembly)
            {
                builder.RegisterType(item.ValidatorType).As(item.InterfaceType);
            }

            var container = builder.Build();

            resolve(container);
            
            return container;
        }
    }
}
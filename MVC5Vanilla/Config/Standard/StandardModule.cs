using Autofac;
using FluentValidation;

namespace MVC5Vanilla.Config.Standard
{
    public class StandardModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AutoFacValidatorFactory>().As<IValidatorFactory>();
            builder.RegisterType<ThingExistsActionFilter>().AsImplementedInterfaces();
            builder.RegisterType<ValidatorActionFilter>().AsImplementedInterfaces();

            base.Load(builder);
        }
    }
}
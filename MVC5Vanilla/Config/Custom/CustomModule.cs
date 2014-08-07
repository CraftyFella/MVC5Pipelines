using Autofac;
using MVC5Vanilla.Controllers;
using MVC5Vanilla.Controllers.Custom;

namespace MVC5Vanilla.Config.Custom
{
    public class CustomModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ThingExistStep>().AsImplementedInterfaces();
            builder.RegisterType<ValidateStep<CustomInput>>().AsImplementedInterfaces();
            builder.RegisterType<PipeLine<CustomInput>>().AsImplementedInterfaces();

            base.Load(builder);
        }
    }
}
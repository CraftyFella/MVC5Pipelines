using System;
using Autofac;
using FluentValidation;

namespace MVC5Vanilla.Config.Standard
{
    public class AutoFacValidatorFactory : ValidatorFactoryBase
    {
        private readonly IComponentContext _componentContext;

        public AutoFacValidatorFactory(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            object instance;
            _componentContext.TryResolve(validatorType, out instance);
            return instance as IValidator;
        }
    }
}
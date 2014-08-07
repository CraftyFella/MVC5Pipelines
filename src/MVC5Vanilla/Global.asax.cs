using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using FluentValidation.Mvc;
using MVC5Vanilla.Config;
using MVC5Vanilla.Config.Standard;

namespace MVC5Vanilla
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            new ContainerFactory().Create(_ =>
            {
                DependencyResolver.SetResolver(new AutofacDependencyResolver(_));
                FluentValidationModelValidatorProvider.Configure(provider => provider.ValidatorFactory = new AutoFacValidatorFactory(_));

                _.Resolve<IEnumerable<IActionFilter>>().ToList().ForEach(f =>  GlobalFilters.Filters.Add(f));
            });
            
        }
    }
}

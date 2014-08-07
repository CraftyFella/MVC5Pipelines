using System.Linq;
using System.Net;
using System.Web.Mvc;
using MVC5Vanilla.Controllers;
using MVC5Vanilla.Controllers.Standard;

namespace MVC5Vanilla.Config.Standard
{
    public class ThingExistsActionFilter : IActionFilter
    {
        private readonly ThingFinder thingFinder;

        public ThingExistsActionFilter(ThingFinder thingFinder)
        {
            this.thingFinder = thingFinder;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!(filterContext.Controller is StandardApproachController)) return;

            var modelsWithRiskId = filterContext.ActionParameters.Values.Where(p => p is IHaveThing);

            foreach (IHaveThing model in modelsWithRiskId)
            {
                if (!thingFinder.Exists(model.Id))
                {
                    filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.NotFound);
                }
            }
            
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }
    }
}
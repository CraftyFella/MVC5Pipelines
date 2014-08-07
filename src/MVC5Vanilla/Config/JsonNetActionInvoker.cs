using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC5Vanilla.Config
{
    public class JsonNetActionInvoker : ControllerActionInvoker
    {
        protected override ActionResult InvokeActionMethod(ControllerContext controllerContext,
            ActionDescriptor actionDescriptor, IDictionary<string, object> parameters)
        {
            var invokeActionMethod = base.InvokeActionMethod(controllerContext, actionDescriptor, parameters);

            return invokeActionMethod.GetType() == typeof(JsonResult) ?
                JsonNetResult.From(invokeActionMethod as JsonResult) :
                invokeActionMethod;
        }
    }
}
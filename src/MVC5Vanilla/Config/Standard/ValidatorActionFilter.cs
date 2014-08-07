using System.Diagnostics;
using System.Net;
using System.Web.Mvc;
using MVC5Vanilla.Controllers;
using MVC5Vanilla.Controllers.Standard;
using Newtonsoft.Json;

namespace MVC5Vanilla.Config.Standard
{
   

    public class ValidatorActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.Controller.ViewData.ModelState.IsValid) return;
            if (!(filterContext.Controller is StandardApproachController)) return;

            var serializationSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var serializedModelState = JsonConvert.SerializeObject(
                filterContext.Controller.ViewData.ModelState,
                serializationSettings);

            var result = new ContentResult
            {
                Content = serializedModelState,
                ContentType = "application/json"
            };

            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            filterContext.Result = result;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }
    }
}
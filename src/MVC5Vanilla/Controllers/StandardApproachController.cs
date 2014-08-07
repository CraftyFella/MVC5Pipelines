using System.Web.Mvc;
using MVC5Vanilla.Controllers.Standard;

namespace MVC5Vanilla.Controllers
{
    public class StandardApproachController : Controller
    {
        [Route("standard"), HttpGet]
        public ActionResult Get(StandardInput input)
        {
            return Json(new {Success = true});
        }
    }
}

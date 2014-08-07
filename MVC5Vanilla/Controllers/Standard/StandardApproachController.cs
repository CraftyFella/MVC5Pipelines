using System.Web.Mvc;

namespace MVC5Vanilla.Controllers.Standard
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

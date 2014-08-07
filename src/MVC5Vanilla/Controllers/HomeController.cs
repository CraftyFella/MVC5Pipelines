using System.Web.Mvc;

namespace MVC5Vanilla.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
	}
}
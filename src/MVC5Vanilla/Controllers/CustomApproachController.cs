using System.Web.Mvc;
using MVC5Vanilla.Config.Custom;
using MVC5Vanilla.Controllers.Custom;

namespace MVC5Vanilla.Controllers
{
    public class CustomApproachController : Controller
    {
        private readonly IPipeLine<CustomInput> pipeline;

        public CustomApproachController(IPipeLine<CustomInput> pipeline)
        {
            this.pipeline = pipeline;
        }

        [Route("custom"), HttpGet]
        public ActionResult Get(CustomInput input)
        {
            return pipeline.Process(input, () => Json(new { Success = true }));
        }
    }
}
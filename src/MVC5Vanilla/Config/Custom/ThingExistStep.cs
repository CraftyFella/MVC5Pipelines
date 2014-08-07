using System.Net;
using System.Web.Mvc;
using MVC5Vanilla.Controllers.Custom;

namespace MVC5Vanilla.Config.Custom
{
    public class ThingExistStep : IPipeLineStep<CustomInput>
    {
        private readonly ThingFinder _finder;

        public ThingExistStep(ThingFinder finder)
        {
            _finder = finder;
        }

        public ActionResult Process(CustomInput data)
        {
            if (!_finder.Exists(data.Id))
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return new Continue();
        }
    }
}
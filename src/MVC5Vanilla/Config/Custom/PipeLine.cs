using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC5Vanilla.Config.Custom
{
    public class PipeLine<TModel> : IPipeLine<TModel>
    {
        private readonly IEnumerable<IPipeLineStep<TModel>> _steps;

        public PipeLine(IEnumerable<IPipeLineStep<TModel>> steps)
        {
            _steps = steps;
        }

        public ActionResult Process(TModel data, Func<ActionResult> success)
        {
            foreach (var step in _steps)
            {
                var actionResult = step.Process(data);
                if (actionResult is Continue)
                    continue;

                return actionResult;
            }

            return success();
        }
    }
}
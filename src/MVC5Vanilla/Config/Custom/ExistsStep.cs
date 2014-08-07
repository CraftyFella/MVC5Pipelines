using System;
using System.Web.Mvc;

namespace MVC5Vanilla.Config.Custom
{
    public class ExistsStep<TData> : IPipeLineStep<TData>
    {
        public ActionResult Process(TData data)
        {
            throw new NotImplementedException();
        }
    }
}
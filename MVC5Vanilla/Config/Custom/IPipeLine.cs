using System;
using System.Web.Mvc;

namespace MVC5Vanilla.Config.Custom
{
    public interface IPipeLine<in TData>
    {
        ActionResult Process(TData data, Func<ActionResult> success);
    }
}
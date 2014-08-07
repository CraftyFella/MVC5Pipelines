using System.Web.Mvc;

namespace MVC5Vanilla.Config.Custom
{
    public interface IPipeLineStep<in TData>
    {
        ActionResult Process(TData data);
    }
}
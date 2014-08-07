using System.Net;
using System.Web.Mvc;
using FluentValidation;
using Newtonsoft.Json;

namespace MVC5Vanilla.Config.Custom
{
    public class ValidateStep<TData> : IPipeLineStep<TData>
    {
        private readonly IValidator<TData> _validator;

        public ValidateStep(IValidator<TData> validator)
        {
            _validator = validator;
        }

        public ActionResult Process(TData data)
        {
            var validationResult = _validator.Validate(data);
            if (!validationResult.IsValid)
            {
                return new JsonNetResult(validationResult)
                {
                    Status = HttpStatusCode.BadRequest
                };
            }

            return new Continue();
        }
    }
}
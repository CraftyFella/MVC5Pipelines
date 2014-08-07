using System;
using System.Net;
using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace MVC5Vanilla.Config
{
    public class JsonNetResult : ActionResult
    {
        public Encoding ContentEncoding { get; set; }
        public string ContentType { get; set; }
        public HttpStatusCode Status { get; set; }
        public object Data { get; set; }

        public JsonSerializerSettings SerializerSettings { get; set; }
        public Formatting Formatting { get; set; }

        public JsonNetResult(object data)
            : this()
        {
            Data = data;
        }

        public static JsonNetResult From(JsonResult existing)
        {
            return new JsonNetResult
            {
                ContentEncoding = existing.ContentEncoding,
                ContentType = existing.ContentType,
                Data = existing.Data
            };
        }

        public JsonNetResult()
        {
            SerializerSettings = new JsonSerializerSettings();
            this.Status = HttpStatusCode.OK;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            var response = context.HttpContext.Response;

            response.ContentType = !string.IsNullOrEmpty(ContentType)
                ? ContentType
                : "application/json";

            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;

            response.StatusCode = (int)Status;
            if (Data != null)
            {
                var writer = new JsonTextWriter(response.Output) { Formatting = Formatting };

                var serializer = JsonSerializer.Create(SerializerSettings);
                serializer.Serialize(writer, Data);

                writer.Flush();
            }
        }
    }
}
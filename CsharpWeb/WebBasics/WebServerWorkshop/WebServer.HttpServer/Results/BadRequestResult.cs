using WebServer.Server.Enums;
using WebServer.Server.Http;

namespace WebServer.Server.Results
{
    public class BadRequestResult : ActionResult
    {
        public BadRequestResult(HttpResponse response) 
            : base(response)
        {
            this.StatusCode = HttpResponseStatusCode.BadRequest;
        }
    }
}

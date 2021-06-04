using WebServer.Server.Enums;

namespace WebServer.Server.Responses
{
    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string location)
            : base(HttpResponseStatusCode.Found) 
            => this.Headers.Add("Location", location);

    }
}

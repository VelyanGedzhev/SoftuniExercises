using WebServer.Server.Enums;
using WebServer.Server.Headers;

namespace WebServer.Server.Responses
{
    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string location)
            : base(HttpResponseStatusCode.Found) 
            => this.Headers.Add(HttpHeader.Location, new HttpHeader(HttpHeader.Location, location));

    }
}

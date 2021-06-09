using System.Text;
using WebServer.Server.Common;
using WebServer.Server.Enums;

namespace WebServer.Server.Responses
{
    public class ContentResponse : HttpResponse
    {
        public ContentResponse(string content, string contentType)
            : base(HttpResponseStatusCode.OK) 
            => this.PrepareContent(content, contentType);
    }
}

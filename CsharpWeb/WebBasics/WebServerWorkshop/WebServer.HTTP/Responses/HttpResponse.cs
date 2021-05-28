using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.HTTP.Enums;
using WebServer.HTTP.Headers;
using WebServer.HTTP.Responses.Contracts;

namespace WebServer.HTTP.Responses
{
    public class HttpResponse : IHttpResponse
    {
        public HttpResponseStatusCode StatusCode { get; private set; }

        public HttpHeaderCollection Headers => new HttpHeaderCollection();

        public string Content { get; init; }
    }
}

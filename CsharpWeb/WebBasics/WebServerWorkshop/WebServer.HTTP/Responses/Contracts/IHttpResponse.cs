using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.HTTP.Enums;
using WebServer.HTTP.Headers;

namespace WebServer.HTTP.Responses.Contracts
{
    public interface IHttpResponse
    {
        HttpResponseStatusCode StatusCode { get; }

        HttpHeaderCollection Headers { get; }

        string Content { get; }
    }
}

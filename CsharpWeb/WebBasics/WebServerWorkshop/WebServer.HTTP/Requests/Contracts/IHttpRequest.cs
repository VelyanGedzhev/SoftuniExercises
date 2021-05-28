using WebServer.HTTP.Enums;
using WebServer.HTTP.Headers;

namespace WebServer.HTTP.Requests.Contracts
{
    interface IHttpRequest
    {
        HttpRequestMethod Method { get; }

        string Url { get; }

        HttpHeaderCollection Headers { get; }

        string Body { get; }
    }
}

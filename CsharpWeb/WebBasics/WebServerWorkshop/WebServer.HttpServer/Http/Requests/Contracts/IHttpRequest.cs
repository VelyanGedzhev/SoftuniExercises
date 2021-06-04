using WebServer.Server.Enums;
using WebServer.Server.Headers;

namespace WebServer.Server.Requests.Contracts
{
    interface IHttpRequest
    {
        HttpRequestMethod Method { get; }

        string Path { get; }

        HttpHeaderCollection Headers { get; }

        string Body { get; }
    }
}

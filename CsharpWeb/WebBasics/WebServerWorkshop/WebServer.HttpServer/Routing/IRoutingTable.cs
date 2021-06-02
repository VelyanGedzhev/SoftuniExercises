using WebServer.Server.Enums;
using WebServer.Server.Responses;

namespace WebServer.Server.Routing
{
    public interface IRoutingTable
    {
        IRoutingTable Map(string url, HttpRequestMethod method, HttpResponse response);

        IRoutingTable MapGet(string url, HttpResponse response);

    }
}

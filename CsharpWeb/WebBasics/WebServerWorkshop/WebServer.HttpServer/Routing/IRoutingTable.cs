using WebServer.Server.Enums;
using WebServer.Server.Responses;

namespace WebServer.Server.Routing
{
    public interface IRoutingTable
    {
        IRoutingTable Map(HttpRequestMethod method, string path, HttpResponse response);

        IRoutingTable MapGet(string path, HttpResponse response);

    }
}

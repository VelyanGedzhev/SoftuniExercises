using System.Threading.Tasks;
using WebServer.Server;
using WebServer.Server.Responses;

namespace WebServer
{
    public class StartUp
    {
        public static async Task Main(string[] args)
            => await new HttpServer(routes => routes
                .MapGet("/", new TextResponse("Simple web -serverwitheducationalpurpose."))
                .MapGet("/Cats", new TextResponse("<h1>Hello from the cats!</h1>", "text/html"))
                .MapGet("/Dogs", new TextResponse("Hello from the dogs!")))
            .Start();
        
    }
}

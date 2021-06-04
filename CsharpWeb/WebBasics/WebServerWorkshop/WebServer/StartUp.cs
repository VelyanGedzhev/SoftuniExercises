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
                .MapGet("/Cats", new HtmlResponse("<h1>Hello from the cats!</h1>"))
                .MapGet("/Dogs", new HtmlResponse("<h1>Hello from the dogs!</h1>")))
            .Start();
        
    }
}

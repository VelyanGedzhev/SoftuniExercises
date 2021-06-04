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
                .MapGet("/Cats", request =>
                {
                    const string nameKey = "Name";

                    var query = request.Query;

                    var name = query.ContainsKey(nameKey)
                        ? query[nameKey]
                        : "the cats";

                    var result = $"<h1>Hello from {name}!</h1>";

                    return new HtmlResponse(result);
                })
                .MapGet("/Dogs", new HtmlResponse("<h1>Hello from the dogs!</h1>")))
            .Start();
        
    }
}

using System.Threading.Tasks;
using WebServer.Controllers;
using WebServer.Server;
using WebServer.Server.Controllers;

namespace WebServer
{
    public class StartUp
    {
        public static async Task Main(string[] args)
            => await new HttpServer(routes => routes
                .MapStaticFiles()
                .MapControllers()
                .MapGet<HomeController>("/tocats", c => c.LocalRedirect())) 
            .Start();
        
    }
}

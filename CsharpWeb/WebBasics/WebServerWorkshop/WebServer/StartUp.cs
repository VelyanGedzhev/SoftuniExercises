using System.Threading.Tasks;
using WebServer.Controllers;
using WebServer.Data;
using WebServer.Server;
using WebServer.Server.Controllers;

namespace WebServer
{
    public class StartUp
    {
        public static async Task Main(string[] args)
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers()
                    .MapGet<HomeController>("/tocats", c => c.LocalRedirect())) 
                .WithServices(services => services
                    .Add<IDataContext, MyDbContext>())
                .Start();
        
    }
}

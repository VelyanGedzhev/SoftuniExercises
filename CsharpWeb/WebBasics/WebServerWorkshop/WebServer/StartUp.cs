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
                .MapGet<HomeController>("/", c => c.Index())
                .MapGet<HomeController>("/tocats", c => c.LocalRedirect())
                .MapGet<HomeController>("/softuni", c => c.ToSoftUni())
                .MapGet<HomeController>("/Error", c => c.Error())
                .MapGet<AnimalsController>("/Cats", c => c.Cats())
                .MapGet<AnimalsController>("/Dogs", c => c.Dogs())
                .MapGet<AnimalsController>("/Turtles", c => c.Turtles())
                .MapGet<AnimalsController>("/Rabbits", c => c.Rabbits())
                .MapGet<AccountController>("/Cookies", c => c.ActionWithCookies())
                .MapGet<AccountController>("/Session", c => c.ActionWithSession())
                .MapGet<CatsController>("/Cats/Create", c => c.Create())
                .MapPost<CatsController>("/Cats/Save", c => c.Save()))  
            .Start();
        
    }
}

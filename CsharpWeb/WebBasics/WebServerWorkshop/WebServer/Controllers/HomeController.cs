using WebServer.Server;
using WebServer.Server.Controllers;
using WebServer.Server.Http;
using WebServer.Server.Responses;

namespace WebServer.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(HttpRequest request) 
            : base(request)
        {
        }

        public HttpResponse Index()
            => Text("Simple web -server with educational purpose.");

        public HttpResponse LocalRedirect()
            => Redirect("/Cats");

        public HttpResponse ToSoftUni() 
            => Redirect("https://softuni.bg");
    }
}

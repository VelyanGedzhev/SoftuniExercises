using System;
using WebServer.Server.Controllers;
using WebServer.Server.Http;

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

        public HttpResponse StaticFiles()
            => View();

        public HttpResponse Error()
            => throw new InvalidOperationException("Invalid operation!");
    }
}

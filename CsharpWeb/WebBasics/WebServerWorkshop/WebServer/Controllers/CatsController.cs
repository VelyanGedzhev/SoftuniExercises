using System.Linq;
using WebServer.Data;
using WebServer.Server.Controllers;
using WebServer.Server.Http;

namespace WebServer.Controllers
{
    public class CatsController : Controller
    {
        private readonly IDataContext data;

        public CatsController(IDataContext data) 
            => this.data = data;

        public HttpResponse All()
        {
            var cats = this.data
                .Cats
                .ToList();

            return View(cats);
        }

        [HttpGet]
        public HttpResponse Create() => View();

        [HttpPost]
        public HttpResponse Save(string name, int age) 
            => Text($"{name} - {age}");
    }
}

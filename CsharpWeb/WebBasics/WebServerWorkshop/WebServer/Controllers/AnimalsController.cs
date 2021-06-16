using WebServer.Models.Animals;
using WebServer.Server.Controllers;
using WebServer.Server.Http;

namespace WebServer.Controllers
{
    public class AnimalsController : Controller
    {
        public HttpResponse Cats()
        {
            const string nameKey = "Name";
            const string ageKey = "Age";

            var query = this.Request.Query;

            var cateName = query.Contains(nameKey)
                ? query[nameKey]
                : "the cats";

            var catAge = query.Contains(ageKey)
                ? int.Parse(query[ageKey])
                : 0;

            var viewModel = new CatViewModel
            {
                Name = cateName,
                Age = catAge
            };

            return View(viewModel);
        }
        public HttpResponse Dogs() => View(new DogViewModel
        {
            Name = "Rex",
            Age = 3,
            Breed = "Street Perfect"
        });

        public HttpResponse Rabbits() => View("Rabbits");

        public HttpResponse Turtles() => View("Animals/Wild/Turtles");
    }
}

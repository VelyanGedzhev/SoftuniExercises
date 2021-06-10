﻿using WebServer.Models.Animals;
using WebServer.Server.Controllers;
using WebServer.Server.Http;
using WebServer.Server.Responses;

namespace WebServer.Controllers
{
    public class AnimalsController : Controller
    {
        public AnimalsController(HttpRequest request)
            : base(request)
        {
        }

        public HttpResponse Cats()
        {
            const string nameKey = "Name";
            const string ageKey = "Age";

            var query = this.Request.Query;

            var cateName = query.ContainsKey(nameKey)
                ? query[nameKey]
                : "the cats";

            var catAge = query.ContainsKey(ageKey)
                ? int.Parse(query[ageKey])
                : 0;

            var viewModel = new CatViewModel
            {
                Name = cateName,
                Age = catAge
            };

            return View(viewModel);
        }

        

        public HttpResponse Dogs() => View();
        
        public HttpResponse Rabbits() => View("Rabbits");

        public HttpResponse Turtles() => View("Animals/Wild/Turtles");
    }
}

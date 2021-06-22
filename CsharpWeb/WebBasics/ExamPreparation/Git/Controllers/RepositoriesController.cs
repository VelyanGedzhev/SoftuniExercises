using Git.Data;
using Git.Data.Models;
using Git.Models.Repositories;
using Git.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Linq;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext data;

        public RepositoriesController(
            IValidator validator,
            ApplicationDbContext data)
        {
            this.validator = validator;
            this.data = data;
        }

        public HttpResponse All()
        {
            var repositories = this.data
                .Repositories
                .Where(r => r.IsPublic == true)
                .Select(r => new RepositoryListingViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Owner = r.Owner.Username,
                    CreatedOn = r.CreatedOn.ToString("g"),
                    CommitsCount = r.Commits.Count
                })
                .ToList();


            return View(repositories);
        }

        [Authorize]
        public HttpResponse Create() => View();

        [Authorize]
        [HttpPost] 
        public HttpResponse Create(AddRepositoryFormModel model)
        {
            var modelErrors = this.validator.ValidateRepository(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var repository = new Repository
            {
                Name = model.Name,
                OwnerId = this.User.Id,
                CreatedOn = DateTime.UtcNow,
                IsPublic = model.RepositoryType == DataConstants.RepositoryPublicType
            };

            this.data.Repositories.Add(repository);
            this.data.SaveChanges();

            return Redirect("/Repositories/All");
        }
    }
}

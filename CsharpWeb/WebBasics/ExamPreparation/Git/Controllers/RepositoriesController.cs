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
        private IRepositoriesService repositoriesService;
        private ApplicationDbContext data;

        public RepositoriesController(
            IRepositoriesService repositoriesService,
            ApplicationDbContext data)
        {
            this.repositoriesService = repositoriesService;
            this.data = data;
        }

        public HttpResponse All()
        {

            if (!this.User.IsAuthenticated)
            {
                return View();
            }

            var repositories = this.data
                .Repositories
                .Where(
                    r => r.IsPublic == true 
                    && r.OwnerId == this.User.Id)
                .Select(r => new RepositoryListingViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Owner = r.Owner.Username,
                    CreatedOn = r.CreatedOn.ToString("f"),
                    CommitsCount = r.Commits.Count
                })
                .ToList();

            return View(repositories);
        }

        public HttpResponse Create() => View();

        [Authorize]
        [HttpPost] 
        public HttpResponse Create(AddRepositoryFormModel model)
        {
            var modelErrors = this.repositoriesService.ValidateRepository(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var repository = new Repository
            {
                Name = model.Name,
                OwnerId = this.User.Id,
                CreatedOn = DateTime.UtcNow,
                IsPublic = model
                    .RepositoryType == DataConstants.RepositoryPublicType
                        ? true
                        : false
            };

            this.data.Repositories.Add(repository);
            this.data.SaveChanges();

            return Redirect("/Repositories/All");
        }

        public HttpResponse Commit(string repoId)
        {
            return Redirect($"/Commits/Create?id{repoId}");
        }
    }
}

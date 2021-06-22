using Git.Data;
using Git.Data.Models;
using Git.Models.Commits;
using Git.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Linq;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {

        private IRepositoriesService repositoriesService;
        private ApplicationDbContext data;

        public CommitsController(
            IRepositoriesService repositoriesService,
            ApplicationDbContext data)
        {
            this.repositoriesService = repositoriesService;
            this.data = data;
        }

        [Authorize]
        public HttpResponse All()
        {
            var commits = this.data
                .Commits
                .Where(c => c.CreatorId == this.User.Id)
                .Select(c => new CommitListingViewModel
                {
                    Id = c.Id,
                    Name = c.Repository.Name,
                    Description = c.Description,
                    CreatedOn = c.CreatedOn.ToString("g")
                    
                })
                .ToList();

            return View(commits);
        }

        [Authorize]
        public HttpResponse Create(string repoId)
        {
            var repository = this.data
                .Repositories
                .FirstOrDefault(r => r.Id == repoId);

            return View(repository);
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateCommitFormModel model)
        {
            var commit = new Commit
            {
                Description = model.Description,
                CreatedOn = DateTime.UtcNow,
                CreatorId = this.User.Id,
                RepositoryId = model.Id
            };

            this.data.Commits.Add(commit);
            this.data.SaveChanges();

            return Redirect("/Repositories/All");
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Delete(string commitId)
        {
            var commit = this.data
                .Commits
                .FirstOrDefault(c => c.Id == commitId);

            this.data.Commits.Remove(commit);

            return Redirect("/Commits/All");
        }
    }
}

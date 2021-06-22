using Git.Data;
using Git.Data.Models;
using Git.Models.Commits;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Linq;

namespace Git.Controllers
{
    using static Data.DataConstants;
    public class CommitsController : Controller
    {
        private readonly ApplicationDbContext data;

        public CommitsController(
            ApplicationDbContext data) => this.data = data;

        [Authorize]
        public HttpResponse All()
        {
            var commits = this.data
                .Commits
                .Where(c => c.CreatorId == this.User.Id)
                .Select(c => new CommitListingViewModel
                {
                    Id = c.Id,
                    Repository = c.Repository.Name,
                    Description = c.Description,
                    CreatedOn = c.CreatedOn.ToString("g")
                    
                })
                .ToList();

            return View(commits);
        }

        [Authorize]
        public HttpResponse Create(string id)
        {
            var repository = this.data
                .Repositories
                .Where(r => r.Id == id)
                .Select(r => new CommitToRepositoryViewModel
                {
                    Id = r.Id,
                    Name = r.Name
                })
                .FirstOrDefault();

            if (repository == null)
            {
                return BadRequest();
            }

            return View(repository);
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateCommitFormModel model)
        {
            if (!this.data.Repositories.Any(r => r.Id == model.Id))
            {
                return Error($"Repository with does not exists.");
            }

            if (model.Description.Length < CommitDescriptionMinLength)
            {
                return Error($"Description '{model.Description}' is invalid. It must be at least {CommitDescriptionMinLength} characters long.");
            }

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
        public HttpResponse Delete(string id)
        {
            var commit = this.data
                .Commits
                .Find(id);

            if (commit == null)
            {
                return Error("There is no such commit.");
            }

            if (commit.CreatorId != this.User.Id)
            {
                return Error("The commit can be deleted only by its owner.");
            }

            this.data.Commits.Remove(commit);
            this.data.SaveChanges();

            return Redirect("/Commits/All");
        }
    }
}

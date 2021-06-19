﻿using CarShop.Data;
using CarShop.Models.Issues;
using CarShop.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Linq;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IValidator validator;
        private readonly IUserService userService;
        private readonly CarShopDbContext data;

        public IssuesController(
            IValidator validator,
            IUserService userService,
            CarShopDbContext data)
        {
            this.validator = validator;
            this.userService = userService;
            this.data = data;
        }

        [Authorize]
        public HttpResponse CarIssues(string carId)
        {
            if (!this.userService.UserIsMechanic(this.User.Id))
            {
                var userOwnsCar = this.data.Cars
                    .Any(c => c.Id == carId && c.OwnerId == this.User.Id);

                if (!userOwnsCar)
                {
                    return Error("You do not have access to this car.");
                }
            }

            var carWithIssues = this.data
                .Cars
                .Where(c => c.Id == carId)
                .Select(c => new CarIssuesViewModel
                {
                    Id = c.Id,
                    Model = c.Model,
                    Year = c.Year,
                    Issues = c.Issues
                        .Select(i => new IssueListingViewModel
                        {
                            Id = i.Id,
                            Description = i.Description,
                            IsFixed = i.IsFixed
                        }).ToList()
                })
                .FirstOrDefault();

            if (carWithIssues == null)
            {
                return Error($"Car with ID: {carId} does not exists!");
            }

            return View(carWithIssues);
        }
    }
}

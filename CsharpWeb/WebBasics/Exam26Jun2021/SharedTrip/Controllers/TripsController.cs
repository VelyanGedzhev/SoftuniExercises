using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Data;
using SharedTrip.Data.Models;
using SharedTrip.Models.Trips;
using SharedTrip.Services;
using System;
using System.Globalization;
using System.Linq;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;
        private readonly ApplicationDbContext data;

        public TripsController(
            IValidator validator,
            IPasswordHasher passwordHasher,
            ApplicationDbContext data)
        {
            this.validator = validator;
            this.passwordHasher = passwordHasher;
            this.data = data;
        }

        [Authorize]
        public HttpResponse All()
        {
            var trips = this.data
                .Trips
                .Select(t => new ListingTripViewModel
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString("g"),
                    Description = t.Description,
                    Seats = t.Seats
                })
                .ToList();

            return View(trips);
        }

        [Authorize]
        public HttpResponse Add() => View();

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddTripFormModel model)
        {
            var modelErrors = this.validator.ValidateTrip(model);

            var departure = DateTime.TryParseExact(
                model.DepartureTime,
                "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime departureTime);

            if (!departure)
            {
                return View();
            }

            if (modelErrors.Any())
            {
                return View();
            }

            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime  = departureTime,
                ImagePath = model.ImagePath,
                Seats = model.Seats,
                Description = model.Description
            };

            this.data.Trips.Add(trip);
            this.data.SaveChanges();

            return Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            var tripInfo = this.data
                .Trips
                .Where(t => t.Id == tripId)
                .Select(t => new ListingTripViewModel
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    ImagePath = t.ImagePath,
                    DepartureTime = t.DepartureTime.ToString("g"),
                    Description = t.Description,
                    Seats = t.Seats
                })
                .FirstOrDefault();

            return View(tripInfo);
        }

        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            var trip = this.data
                .Trips
                .FirstOrDefault(t => t.Id == tripId);

            if (trip == null)
            {
                return Redirect($"/Trips/Details?tripId={tripId}");
            }

            if (trip.Seats < 1)
            {
                return Redirect($"/Trips/Details?tripId={tripId}");
            }

            var userTrip = this.data.UserTrips
                .Where(t => t.TripId == tripId && t.UserId == this.User.Id)
                .FirstOrDefault();

            if (userTrip != null)
            {
                return Redirect($"/Trips/Details?tripId={tripId}");
            }

            var userTripToAdd = new UserTrip
            {
                UserId = this.User.Id,
                TripId = tripId
            };

            this.data.UserTrips.Add(userTripToAdd);
            trip.Seats -= 1;
            this.data.SaveChanges();

            return Redirect("/Trips/All");
        }
    }
}

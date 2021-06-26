using SharedTrip.Models.Trips;
using SharedTrip.Models.Users;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SharedTrip.Services
{
    using static Data.DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateTrip(AddTripFormModel trip)
        {
            var errors = new List<string>();

            if (trip.StartPoint == null || trip.EndPoint == null)
            {
                errors.Add("Cannot add trip without StartPoint and EndPoint.");
            }

            if (trip.DepartureTime == null)
            {
                errors.Add("Cannot add trip without Departure Time.");
            }


            if (trip.Seats < TripSeatsMin || trip.Seats > TripSeatsMax)
            {
                errors.Add($"Invalid seats count. They must be between {TripSeatsMin} and {TripSeatsMax}.");
            }

            if (trip.Description == null || trip.Description.Length > TripDescriptionMaxLength)
            {
                errors.Add($"Invalid trip description. It must be up to {TripDescriptionMaxLength} characters long.");
            }


            return errors;
        }

        public ICollection<string> ValidateUser(RegisterUserFormModel user)
        {
            var errors = new List<string>();

            if (user.Username == null || user.Username.Length < UsernameMinLength
                || user.Username.Length > UsernameMaxLength)
            {
                errors.Add($"Username {user.Username} is not valid! It must be between {UsernameMinLength} and {UsernameMaxLength} characters long.");
            }

            if (user.Email == null || !Regex.IsMatch(user.Email, UserEmailRegularExpression))
            {
                errors.Add("Invalid e-mail address.");
            }

            if (user.Password == null || user.Password.Length < UserMinPassword
                || user.Password.Length > UserMaxPassword)
            {
                errors.Add($"Password must be between {UserMinPassword} and {UserMaxPassword} characters long.");
            }

            if (user.Password == null || !user.Password.Equals(user.ConfirmPassword))
            {
                errors.Add("Passwords are not matching.");
            }

            return errors;
        }
    }
}

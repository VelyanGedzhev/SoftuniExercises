using CarShop.Models.Cars;
using CarShop.Models.Users;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CarShop.Services
{
    using static Data.DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateCar(AddCarFormModel model)
        {
            var errors = new List<string>();

            if (model.Model.Length < CarModelMinLength
                || model.Model.Length > DefaultMaxLength)
            {
                errors.Add($"Car Model '{model.Model}' is not valid! It must be between {CarModelMinLength} and {DefaultMaxLength} characters long.");
            }

            if (!Regex.IsMatch(model.PlateNumber, CarPlateNumberValidator))
            {
                errors.Add($"Car plate '{model.PlateNumber}' is not valid. It must match the following format - 'XX0000XX'.");
            }

            if (model.Year < CarYearMinValue
                || model.Year > CarYearMaxValue)
            {
                errors.Add($"Car 'Year' must be between {CarYearMinValue} and {CarYearMaxValue}.");
            }


            return errors;
        }

        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();
            
            if (model.Username.Length < UsernameMinLength
                || model.Username.Length > DefaultMaxLength)
            {
                errors.Add($"Username {model.Username} is not valid! It must be between {UsernameMinLength} and {DefaultMaxLength} characters long.");
            }

            if (!Regex.IsMatch(model.Email, UserEmailValidator))
            {
                errors.Add("Invalid e-mail address.");
            }

            if (model.Password.Length < UserPasswordMinLength
                || model.Password.Length > DefaultMaxLength)
            {
                errors.Add($"Password must be between {UserPasswordMinLength} and {DefaultMaxLength} characters long."); 
            }

            if (!model.Password.Equals(model.ConfirmPassword))
            {
                errors.Add("Passwords are not matching.");
            }

            if (model.UserType != UserTypeMechanic
                && model.UserType != UserTypeClient)
            {
                errors.Add($"UserType can be only '{UserTypeMechanic}' or '{UserTypeClient}'.");
            }

            return errors;
        }
    }
}

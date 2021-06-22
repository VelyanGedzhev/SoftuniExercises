using Git.Models.Users;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Git.Services
{
    using static Data.DataConstants;


    public class UsersService : IUsersService
    {
        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UsernameMinLength 
                || model.Username.Length > UserDefaultMaxLength)
            {
                errors.Add($"Username: '{model.Username}' is invalid. It must be between {UsernameMinLength} and {UserDefaultMaxLength} characters long.");
            }

            if (!Regex.IsMatch(model.Email, UserEmailValidator))
            {
                errors.Add("Invalid e-mail address.");
            }

            if (model.Password.Length < UserPasswordMinLength 
                || model.Password.Length > UserDefaultMaxLength)
            {
                errors.Add($"Password is invalid. It must be between {UserPasswordMinLength} and {UserDefaultMaxLength} characters long.");
            }

            if (!model.Password.Equals(model.ConfirmPassword))
            {
                errors.Add("Password and Confirm Password must match.");
            }

            return errors;
        }
    }
}

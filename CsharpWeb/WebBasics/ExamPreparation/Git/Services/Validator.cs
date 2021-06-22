using Git.Models.Repositories;
using Git.Models.Users;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Git.Services
{
    using static Data.DataConstants;

    public class Validator : IValidator
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

            if (model.Password.Any(x => x == ' '))
            {
                errors.Add("The password cannot include whitespaces.");
            }

            if (!model.Password.Equals(model.ConfirmPassword))
            {
                errors.Add("Password and Confirm Password must match.");
            }

            return errors;
        }

        public ICollection<string> ValidateRepository(AddRepositoryFormModel model)
        {
            var errors = new List<string>();

            if (model.Name.Length < RepositoryNameMinLength
                || model.Name.Length > RepositoryNameMaxLength)
            {
                errors.Add($"Repository name: '{model.Name}' is invalid. It must be between {RepositoryNameMinLength} and {RepositoryNameMaxLength} characters long.");
            }

            if (model.RepositoryType != RepositoryPrivateType
                && model.RepositoryType != RepositoryPublicType)
            {
                errors.Add($"Repository type can be either {RepositoryPublicType} or {RepositoryPrivateType}.");
            }

            return errors;
        }

    }
}


using BattleCards.Models.Cards;
using BattleCards.Models.Users;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BattleCards.Services
{
    using static Data.DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateCard(AddCardFormModel model)
        {
            var errors = new List<string>();

            if (model.Name.Length < DefaultMinLength
                || model.Name.Length > CardNameMaxLength)
            {
                errors.Add($"Car Model '{model.Name}' is not valid! It must be between {DefaultMinLength} and {CardNameMaxLength} characters long.");
            }

            if (model.Attack < CardDefaultMinStat)
            {
                errors.Add($"Attack stat {model.Attack} is invalid. Card {nameof(model.Attack)} cannot be negative.");
            }

            if (model.Health < CardDefaultMinStat)
            {
                errors.Add($"Attack stat {model.Health} is invalid. Card {nameof(model.Health)} cannot be negative.");
            }

            if (model.Description.Length > CardDescriptionMaxLength)
            {
                errors.Add($"Invalid card Description. It must be up to {CardDescriptionMaxLength} characters long.");
            }


            return errors;
        }

        public string ValidateIssue(string description)
        {

            if (string.IsNullOrWhiteSpace(description))
            {
                return ($"The '{description}' is not valid. Must be at least 5 characters long.");
            }

            return string.Empty;
        }

        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < DefaultMinLength
                || model.Username.Length > DefaultMaxLength)
            {
                errors.Add($"Username {model.Username} is not valid! It must be between {DefaultMinLength} and {DefaultMaxLength} characters long.");
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

            return errors;
        }
    }
}

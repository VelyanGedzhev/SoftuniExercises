using CarShop.Models.Cars;
using CarShop.Models.Users;
using System.Collections.Generic;

namespace CarShop.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model); 

        ICollection<string> ValidateCar(AddCarFormModel model); 

        string ValidateIssue(string description); 
    }
}

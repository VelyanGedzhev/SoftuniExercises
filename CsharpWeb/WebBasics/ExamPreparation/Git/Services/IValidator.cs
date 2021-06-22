using Git.Data.Models;
using Git.Models.Repositories;
using Git.Models.Users;
using System.Collections.Generic;

namespace Git.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);

        ICollection<string> ValidateRepository(AddRepositoryFormModel model);


    }
}

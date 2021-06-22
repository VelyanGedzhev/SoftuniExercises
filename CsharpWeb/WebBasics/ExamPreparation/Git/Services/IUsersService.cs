using Git.Models.Users;
using System.Collections.Generic;

namespace Git.Services
{
    public interface IUsersService
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);
    }
}

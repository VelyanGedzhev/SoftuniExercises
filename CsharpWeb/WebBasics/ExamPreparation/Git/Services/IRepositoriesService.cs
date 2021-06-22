using Git.Models.Repositories;
using System.Collections.Generic;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        ICollection<string> ValidateRepository(AddRepositoryFormModel model);
    }
}

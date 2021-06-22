using Git.Models.Repositories;
using System.Collections.Generic;

namespace Git.Services
{
    using static Data.DataConstants;

    public class RepositoriesService : IRepositoriesService
    {

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

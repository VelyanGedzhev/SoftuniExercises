using System;
using System.ComponentModel.DataAnnotations;

namespace Git.Data.Models
{
    using static DataConstants;

    public class Commit
    {

        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string Description { get; init; }

        public DateTime CreatedOn { get; init; }

        public string CreatorId { get; init; }

        public User Creator { get; init; }

        public string RepositoryId { get; init; }

        public Repository Repository { get; init; }
    }
}
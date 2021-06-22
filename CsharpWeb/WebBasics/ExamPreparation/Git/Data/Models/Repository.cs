using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Git.Data.Models
{
    using static DataConstants;
    public class Repository
    {
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(RepositoryNameMaxLength)]
        public string Name { get; init; }

        public DateTime CreatedOn { get; init; }

        public bool IsPublic { get; init; }

        public string OwnerId { get; init; }

        public User Owner { get; init; }

        public ICollection<Commit> Commits { get; init; } = new List<Commit>();


    }
}
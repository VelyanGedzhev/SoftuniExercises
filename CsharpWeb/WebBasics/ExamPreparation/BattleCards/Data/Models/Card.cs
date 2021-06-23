using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BattleCards.Data.Models
{
    using static Data.DataConstants;

    public class Card
    {
        [Key]
        [Required]
        public int Id { get; init; }

        [Required]
        [MaxLength(CardNameMaxLength)]
        public string Name { get; init; }

        [Required]
        public string ImageUrl { get; init; }

        [Required]
        public string Keyword { get; init; }

        public int Attack { get; init; }

        public int Health { get; init; }

        [Required]
        [MaxLength(CardDescriptionMaxLength)]
        public string Description { get; init; }

        public ICollection<UserCard> UserCards { get; init; } = new List<UserCard>();
    }
}
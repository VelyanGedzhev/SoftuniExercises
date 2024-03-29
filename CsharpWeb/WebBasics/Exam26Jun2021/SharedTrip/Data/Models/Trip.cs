﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Data.Models
{
    using static Data.DataConstants;
    
    public class Trip
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string StartPoint { get; set; }

        [Required]
        public string EndPoint { get; set; }

        public DateTime DepartureTime { get; set; }

        public int Seats { get; set; }

        [Required]
        [MaxLength(TripDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public ICollection<UserTrip> UserTrips { get; init; } = new List<UserTrip>();
    }
}

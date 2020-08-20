using Cinema.Data.Models.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.Models
{
    public class Movie
    {
        public Movie()
        {
            Projections = new HashSet<Projection>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(20)]
        public string Title { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required, MinLength(1), MaxLength(10)]
        public double Rating { get; set; }

        [Required, MinLength(3), MaxLength(20)]
        public string Director { get; set; }

        public ICollection<Projection> Projections { get; set; }
    }
}

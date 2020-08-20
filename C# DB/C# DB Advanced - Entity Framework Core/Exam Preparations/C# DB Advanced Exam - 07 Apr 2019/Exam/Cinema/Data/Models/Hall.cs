using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cinema.Data.Models
{
    public class Hall
    {
        public Hall()
        {
            Projections = new HashSet<Projection>();
            Seats = new HashSet<Seat>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        public bool Is4Dx { get; set; }

        public bool Is3D { get; set; }

        public ICollection<Projection> Projections { get; set; }

        public ICollection<Seat> Seats { get; set; }
    }
}

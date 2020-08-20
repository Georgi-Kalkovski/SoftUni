using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MusicHub.Data.Models
{
    public class SongPerformer
    {
        [Required, ForeignKey("Song")]
        public int SongId { get; set; }
        public Song Song { get; set; }

        [Required, ForeignKey("Performer")]
        public int PerformerId { get; set; }
        public Performer Performer { get; set; }
    }
}

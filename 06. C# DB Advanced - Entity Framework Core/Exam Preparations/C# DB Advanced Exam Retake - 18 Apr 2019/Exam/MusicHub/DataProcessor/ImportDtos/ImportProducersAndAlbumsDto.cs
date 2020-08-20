using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.DataProcessor.ImportDtos
{
    public class ImportProducersAndAlbumsDto
    {
        [Required, MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+ [A-Z][a-z]+$")]
        public string Pseudonym { get; set; }

        [RegularExpression(@"^\+359 \d{3} \d{3} \d{3}$")]
        public string PhoneNumber { get; set; }

        public List<AlbumDto> Albums { get; set; }
    }

    public class AlbumDto
    {
        [Required, MinLength(3), MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public string ReleaseDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Performer")]
    public class ImportSongPerformersDto
    {
        [Required, MinLength(3), MaxLength(20)]
        public string FirstName { get; set; }

        [Required, MinLength(3), MaxLength(20)]
        public string LastName { get; set; }

        [Required, Range(18, 70)]
        public int Age { get; set; }

        [Required, Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal NetWorth { get; set; }
        
        [XmlArray("PerformersSongs")]
        public List<SongsDto> PerformerSongs { get; set; }
    }
    [XmlType("Song")]
    public class SongsDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}

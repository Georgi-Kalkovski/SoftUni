using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUsersАndCardsDto
    {
        [Required, RegularExpression(@"^[A-Z][a-z]+ [A-Z][a-z]+$")]
        public string FullName { get; set; }

        [Required, MinLength(3), MaxLength(20)]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Range(3, 103)]
        public int Age { get; set; }

        public List<CardDto> Cards { get; set; }
    }

    public class CardDto
    {
        [Required, RegularExpression(@"^\d{4} \d{4} \d{4} \d{4}$")]
        public string Number { get; set; }

        [JsonProperty("CVC")]
        [Required, RegularExpression(@"\d{3}")]
        public string Cvc { get; set; }

        [Required]
        public string Type { get; set; }
    }
}

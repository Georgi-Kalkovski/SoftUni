using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeeDto
    {
        [JsonProperty("Username")]
        [Required,MinLength(3), MaxLength(40), RegularExpression(@"^[a-zA-Z0-9]+$")]
        public string Username { get; set; }

        [JsonProperty("Email")]
        [Required, EmailAddress]
        public string Email { get; set; }

        [JsonProperty("Phone")]
        [Required, RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
        public string Phone { get; set; }

        [JsonProperty("Tasks")]
        public int[] Tasks { get; set; }
    }
}

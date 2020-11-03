namespace ShoutsShare.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ShoutsShare.Data.Common.Models;

    using static ShoutsShare.Data.Common.DataValidation.Country;

    public class Country : BaseDeletableModel<int>
    {
        public Country()
        {
            this.ContentCountries = new HashSet<VideoCountry>();
        }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public ICollection<VideoCountry> ContentCountries { get; set; }
    }
}
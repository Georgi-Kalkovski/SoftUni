using ShoutsShare.Data.Common.Models;
using System;

namespace ShoutsShare.Data.Models
{
    public class VideoCountry : IDeletableEntity
    {
        public int VideoId { get; set; }

        public virtual Video Video { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
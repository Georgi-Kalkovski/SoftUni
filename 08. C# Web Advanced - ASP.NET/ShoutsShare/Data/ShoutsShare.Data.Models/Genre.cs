using ShoutsShare.Data.Common.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static ShoutsShare.Data.Common.DataValidation.Genre;

namespace ShoutsShare.Data.Models
{
    public class Genre : BaseDeletableModel<int>
    {
        public Genre()
        {
            this.ContentGenres = new HashSet<VideoGenre>();
        }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<VideoGenre> ContentGenres { get; set; }
    }
}
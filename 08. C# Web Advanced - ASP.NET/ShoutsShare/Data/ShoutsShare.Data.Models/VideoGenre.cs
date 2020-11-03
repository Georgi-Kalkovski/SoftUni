using ShoutsShare.Data.Common.Models;
using System;

namespace ShoutsShare.Data.Models
{
    public class VideoGenre : IDeletableEntity
    {
        public int VideoId { get; set; }

        public virtual Video Video { get; set; }

        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
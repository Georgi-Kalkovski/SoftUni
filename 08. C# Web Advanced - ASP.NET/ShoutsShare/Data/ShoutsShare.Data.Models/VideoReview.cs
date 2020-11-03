using ShoutsShare.Data.Common.Models;
using System;

namespace ShoutsShare.Data.Models
{
    public class VideoReview : IDeletableEntity
    {
        public int VideoId { get; set; }

        public virtual Video Video { get; set; }

        public int? ReviewId { get; set; }

        public virtual Review Review { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
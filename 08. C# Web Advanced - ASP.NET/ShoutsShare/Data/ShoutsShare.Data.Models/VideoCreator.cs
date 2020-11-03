using ShoutsShare.Data.Common.Models;
using System;

namespace ShoutsShare.Data.Models
{
    public class VideoCreator : IDeletableEntity
    {
        public int VideoId { get; set; }

        public virtual Video Video { get; set; }

        public int CreatorId { get; set; }

        public virtual Creator Creator { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
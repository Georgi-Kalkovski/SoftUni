using ShoutsShare.Data.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ShoutsShare.Data.Models
{
    public class ShoutsRating : BaseDeletableModel<int>
    {
        public int Rate { get; set; }

        public int VideoId { get; set; }

        public virtual Video Video { get; set; }

        [Required]
        public string UserId { get; set; }

        public ContentWorldUser User { get; set; }

        public DateTime NextVoteDate { get; set; }
    }
}
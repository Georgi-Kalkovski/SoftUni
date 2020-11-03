using ShoutsShare.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static ShoutsShare.Data.Common.DataValidation.Review;

namespace ShoutsShare.Data.Models
{
    public class Review : BaseDeletableModel<int>
    {
        public Review()
        {
            this.ContentReviews = new HashSet<VideoReview>();
        }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<VideoReview> ContentReviews { get; set; }
    }
}
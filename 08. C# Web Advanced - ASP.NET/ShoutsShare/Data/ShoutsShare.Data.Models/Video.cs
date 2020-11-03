using ShoutsShare.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static ShoutsShare.Data.Common.DataValidation.Video;

namespace ShoutsShare.Data.Models
{
    public class Video : BaseDeletableModel<int>
    {
        public Video()
        {
            this.VideoGenres = new HashSet<VideoGenre>();
            this.VideoReviews = new HashSet<VideoReview>();
            this.VideoCountries = new HashSet<VideoCountry>();
            this.VideoCreators = new HashSet<VideoCreator>();
            this.ShoutsRatings = new HashSet<ShoutsRating>();
            this.VideoComments = new HashSet<VideoComment>();
        }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfRelease { get; set; }

        public string Resolution { get; set; } // HD, SD quality

        public decimal Rating { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(LanguageMaxLength)]
        public string Language { get; set; }

        [Required]
        [MaxLength(CoverPathMaxLength)]
        public string CoverPath { get; set; }

        [Required]
        [MaxLength(ThumbnailPathMaxLength)]
        public string ThumbnailPath { get; set; }

        [MaxLength(YoutubeLinkMaxLength)]
        public string YoutubeLink { get; set; }

        public int Length { get; set; }

        public int CreatorId { get; set; }

        public virtual Creator Creator { get; set; }

        public virtual ICollection<VideoGenre> VideoGenres { get; set; }

        public virtual ICollection<VideoReview> VideoReviews { get; set; }

        public virtual ICollection<VideoCountry> VideoCountries { get; set; }

        public virtual ICollection<VideoCreator> VideoCreators { get; set; }

        public virtual ICollection<ShoutsRating> ShoutsRatings { get; set; }

        public virtual ICollection<VideoComment> VideoComments { get; set; }
    }
}

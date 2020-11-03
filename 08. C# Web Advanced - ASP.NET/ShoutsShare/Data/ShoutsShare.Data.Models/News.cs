using ShoutsShare.Data.Common.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static ShoutsShare.Data.Common.DataValidation.News;

namespace ShoutsShare.Data.Models
{
    public class News : BaseDeletableModel<int>
    {
        public News()
        {
            this.NewsComments = new HashSet<NewsComment>();
        }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(ShortDescriptionMaxLength)]
        public string ShortDescription { get; set; }

        [Required]
        [MaxLength(ImagePathMaxLength)]
        public string ImagePath { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ContentWorldUser User { get; set; }

        public int ViewsCounter { get; set; }

        public bool IsUpdated { get; set; }

        public virtual ICollection<NewsComment> NewsComments { get; set; }
    }
}
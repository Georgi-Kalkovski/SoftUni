namespace ShoutsShare.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Identity;
    using ShoutsShare.Data.Common;
    using ShoutsShare.Data.Common.Models;
    using ShoutsShare.Data.Models.Enumerations;

    public class ContentWorldUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ContentWorldUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();

            this.News = new HashSet<News>();
            this.Comments = new HashSet<VideoComment>();
            this.NewsComments = new HashSet<NewsComment>();
        }

        [Required]
        [MaxLength(DataValidation.FullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<News> News { get; set; }

        public virtual ICollection<VideoComment> Comments { get; set; }

        public virtual ICollection<NewsComment> NewsComments { get; set; }
    }
}
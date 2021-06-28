// ReSharper disable VirtualMemberCallInConstructor
namespace MyPetProject.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;
    using MyPetProject.Data.Common.Models;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Kingdoms = new HashSet<Kingdom>();
            this.Breeds = new HashSet<Breed>();
            this.Subbreeds = new HashSet<Subbreed>();
            this.FoodTypes = new HashSet<FoodType>();
            this.Foods = new HashSet<Food>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public ICollection<Kingdom> Kingdoms { get; set; }

        public ICollection<Breed> Breeds { get; set; }

        public ICollection<Subbreed> Subbreeds { get; set; }

        public ICollection<FoodType> FoodTypes { get; set; }

        public ICollection<Food> Foods { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}

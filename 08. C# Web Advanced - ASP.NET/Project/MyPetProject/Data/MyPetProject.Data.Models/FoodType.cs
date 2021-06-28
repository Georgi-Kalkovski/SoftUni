namespace MyPetProject.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using MyPetProject.Data.Common.Models;

    public class FoodType : BaseDeletableModel<int>
    {
        public FoodType()
        {
            this.Foods = new HashSet<Food>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PicUrl { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public virtual ICollection<Food> Foods { get; set; }
    }
}

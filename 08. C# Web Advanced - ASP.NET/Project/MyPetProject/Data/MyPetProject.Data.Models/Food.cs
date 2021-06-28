namespace MyPetProject.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using MyPetProject.Data.Common.Models;

    public class Food : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string PicUrl { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [ForeignKey(nameof(FoodType))]
        public int FoodTypeId { get; set; }

        public FoodType FoodType { get; set; }

        [Required]
        [ForeignKey(nameof(Subbreed))]
        public int SubbreedId { get; set; }

        public Subbreed Subbreed { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}

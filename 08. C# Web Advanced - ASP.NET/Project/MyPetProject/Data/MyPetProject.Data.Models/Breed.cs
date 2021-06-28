namespace MyPetProject.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using MyPetProject.Data.Common.Models;

    public class Breed : BaseDeletableModel<int>
    {
        public Breed()
        {
            this.Subbreeds = new HashSet<Subbreed>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PicUrl { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [ForeignKey(nameof(Kingdom))]
        public int KingdomId { get; set; }

        public Kingdom Kingdom { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public virtual ICollection<Subbreed> Subbreeds { get; set; }
    }
}

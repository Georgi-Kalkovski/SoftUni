namespace MyPetProject.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using MyPetProject.Data.Common.Models;

    public class Kingdom : BaseDeletableModel<int>
    {
        public Kingdom()
        {
            this.Breeds = new HashSet<Breed>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PicUrl { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<Breed> Breeds { get; set; }
    }
}

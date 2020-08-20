using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

using PetStore.Common;

namespace PetStore.Models
{
    public class Breed
    {
        public Breed()
        {
            this.Pets = new HashSet<Pet>();    
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.BreedNameMinLength)]
        public string Name { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}

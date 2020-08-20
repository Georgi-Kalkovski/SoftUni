using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace RealEstates.Models
{
    public class BuildingType
    {
        public BuildingType()
        {
            this.Properties = new HashSet<RealEstateProperty>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<RealEstateProperty> Properties { get; set; }
    }
}

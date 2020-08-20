using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstates.Models
{
    public class District
    {
        public District()
        {
            this.Properties = new HashSet<RealEstateProperty>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<RealEstateProperty> Properties { get; set; }
    }
}

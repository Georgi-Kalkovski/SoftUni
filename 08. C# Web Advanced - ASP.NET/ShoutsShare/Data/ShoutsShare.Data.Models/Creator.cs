using ShoutsShare.Data.Common;
using ShoutsShare.Data.Common.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoutsShare.Data.Models
{
    public class Creator : BaseDeletableModel<int>
    {
        public Creator()
        {
            this.Contents = new HashSet<Video>();
        }

        [Required]
        [MaxLength(DataValidation.NameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(DataValidation.NameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(DataValidation.NameMaxLength)]
        public string Nickname { get; set; }

        public virtual ICollection<Video> Contents { get; set; }
    }
}
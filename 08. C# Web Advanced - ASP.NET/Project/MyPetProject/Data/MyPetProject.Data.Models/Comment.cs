namespace MyPetProject.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using MyPetProject.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime DateTime { get; set; }
    }
}

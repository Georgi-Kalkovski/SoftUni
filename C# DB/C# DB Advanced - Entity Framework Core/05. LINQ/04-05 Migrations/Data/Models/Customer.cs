namespace P03_SalesDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(80)]
        public string Email { get; set; }

        [Required]
        public string CreditCardNumber { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}

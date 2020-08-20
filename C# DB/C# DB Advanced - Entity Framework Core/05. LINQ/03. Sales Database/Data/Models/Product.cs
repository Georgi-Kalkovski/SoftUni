namespace P03_SalesDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public double Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ICollection<Sale> Sales { get; set; }

    }
}

namespace P03_SalesDatabase.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Sale
    {
        [Key]
        public int SaleId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required, ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required, ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required, ForeignKey("Store")]
        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}

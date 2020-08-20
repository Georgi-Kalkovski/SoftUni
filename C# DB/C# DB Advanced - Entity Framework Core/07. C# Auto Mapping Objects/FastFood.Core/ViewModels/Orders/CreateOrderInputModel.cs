namespace FastFood.Core.ViewModels.Orders
{
    using System.ComponentModel.DataAnnotations;

    public class CreateOrderInputModel
    {
        [Required]
        public string Customer { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        [Range(11, 1000)]
        public int Quantity { get; set; }
    }
}
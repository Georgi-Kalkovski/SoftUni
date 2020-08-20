using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PetStore.Common;

namespace PetStore.Models
{
    public class ClientProduct
    {
        [Required]
        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; }
        public virtual Client Client { get; set; }

        [Required]
        [ForeignKey(nameof(Product))]
        public string ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Range(GlobalConstants.ClientProductMinQuantity, Int32.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [ForeignKey(nameof(Order))]
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}

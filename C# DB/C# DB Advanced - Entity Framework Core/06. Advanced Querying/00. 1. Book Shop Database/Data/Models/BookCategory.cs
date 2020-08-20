using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookShop.Data.Models
{
    public class BookCategory
    {
        [Required, ForeignKey("Book")]
        public int BooktId { get; set; }
        public Book Book { get; set; }


        [Required, ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

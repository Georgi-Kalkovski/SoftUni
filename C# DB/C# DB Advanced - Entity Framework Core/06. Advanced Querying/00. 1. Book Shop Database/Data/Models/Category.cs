using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.BookCategories = new HashSet<BookCategory>();
        }

        [Key]
        public int CategoryId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public ICollection<BookCategory> BookCategories { get; set; }
    }
}

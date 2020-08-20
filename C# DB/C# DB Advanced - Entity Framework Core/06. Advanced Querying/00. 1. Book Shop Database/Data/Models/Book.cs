using BookShop.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookShop.Data.Models
{
    public class Book
    {
        public Book()
        {
            this.BookCategories = new HashSet<BookCategory>();
        }

        [Key]
        public int BookId { get; set; }

        [Required, MaxLength(50)]
        public string Title { get; set; }

        [Required,MaxLength(1000)]
        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Required]
        public int Copies { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public EditionType EditionType { get; set; }

        [Required]
        public AgeRestriction AgeRestriction { get; set; }

        [Required, ForeignKey("Author")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public ICollection<BookCategory> BookCategories { get; set; }
    }
}

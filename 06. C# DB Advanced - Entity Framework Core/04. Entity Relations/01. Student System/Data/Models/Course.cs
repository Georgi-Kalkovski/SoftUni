namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {
        [Key, Required]
        public int CourseId { get; set; }

        [MaxLength(80), Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public ICollection<StudentCourse> StudentsEnrolled { get; set; }

        [Required]
        public ICollection<Resource> Resources { get; set; }

        [Required]
        public ICollection<Homework> HomeworkSubmissions { get; set; }
    }
}

namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
            : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity
                    .HasKey(s => s.StudentId);

                entity
                    .Property(s => s.Name)
                    .IsRequired(true)
                    .IsUnicode(true)
                    .HasMaxLength(100);

                entity
                    .Property(s => s.PhoneNumber)
                    .IsRequired(false)
                    .IsUnicode(false)
                    .HasMaxLength(10);

                entity
                    .Property(s => s.RegisteredOn)
                    .IsRequired(true);


                entity
                    .Property(s => s.Birthday)
                    .IsRequired(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity
                    .HasKey(c => c.CourseId);

                entity
                    .Property(c => c.Name)
                    .IsRequired(true)
                    .IsUnicode(true)
                    .HasMaxLength(80);

                entity
                    .Property(c => c.Description)
                    .IsRequired(false)
                    .IsUnicode(true);

                entity
                    .Property(c => c.StartDate)
                    .IsRequired(true);

                entity
                    .Property(c => c.EndDate)
                    .IsRequired(true);

                entity
                    .Property(c => c.Price)
                    .IsRequired(true);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity
                    .HasKey(r => r.ResourceId);

                entity
                    .Property(r => r.Name)
                    .IsRequired(true)
                    .IsUnicode(true)
                    .HasMaxLength(50);

                entity
                    .Property(r => r.Url)
                    .IsRequired(true)
                    .IsUnicode(false);

                entity
                    .Property(r => r.ResourceType)
                    .IsRequired(true);

                entity
                    .Property(r => r.CourseId)
                    .IsRequired(true);

                entity
                    .HasOne(e => e.Course)
                    .WithMany(c => c.Resources)
                    .HasForeignKey(c => c.CourseId);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity
                    .HasKey(h => h.HomeworkId);

                entity
                    .Property(h => h.Content)
                    .IsRequired(true)
                    .IsUnicode(false);

                entity
                    .Property(h => h.ContentType)
                    .IsRequired(true);

                entity
                    .Property(h => h.SubmissionTime)
                    .IsRequired(true);

                entity
                    .Property(h => h.StudentId)
                    .IsRequired(true);

                entity
                    .HasOne(h => h.Student)
                    .WithMany(s => s.HomeworkSubmissions)
                    .HasForeignKey(s => s.StudentId);

                entity
                    .Property(h => h.CourseId);

                entity
                    .HasOne(h => h.Course)
                    .WithMany(h => h.HomeworkSubmissions)
                    .HasForeignKey(h => h.CourseId);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity
                    .HasKey(sc => new { sc.StudentId, sc.CourseId });

                entity
                    .HasOne(sc => sc.Student)
                    .WithMany(s => s.CourseEnrollments)
                    .HasForeignKey(sc => sc.StudentId);

                entity
                    .HasOne(sc => sc.Course)
                    .WithMany(s => s.StudentsEnrolled)
                    .HasForeignKey(sc => sc.CourseId);
            });
        }
    }
}

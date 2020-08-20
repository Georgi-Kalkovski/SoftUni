namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;

    public class SalesContext : DbContext
    {

        public SalesContext()
        {
        }

        public SalesContext(DbContextOptions<SalesContext> options) 
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-GHV5K6M\\MSSQLSERVER01;Database=Sales Database;Integrated Security=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(x => x.Email).IsUnicode(false);
            modelBuilder.Entity<Sale>().Property(x => x.Date).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Product>().Property(x => x.Description).HasDefaultValue("No description");
        }

        public DbSet<Sale> Sales { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }

    }
}

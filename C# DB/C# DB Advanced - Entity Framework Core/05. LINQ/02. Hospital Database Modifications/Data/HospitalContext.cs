namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data.Models;

    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions<HospitalContext> options) 
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-GHV5K6M\\MSSQLSERVER01;Database=Hospital Database;Integrated Security=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().Property(x => x.Email).IsUnicode(false);
            modelBuilder.Entity<PatientMedicament>(x=> 
            x.HasKey(x => new { x.PatientId, x.MedicamentId }));
        }

        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Visitation> Visitations { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Diagnose> Diagnoses { get; set; }
        public virtual DbSet<Medicament> Medicaments { get; set; }
        public virtual DbSet<PatientMedicament> PatientMedicaments { get; set; }

    }
}

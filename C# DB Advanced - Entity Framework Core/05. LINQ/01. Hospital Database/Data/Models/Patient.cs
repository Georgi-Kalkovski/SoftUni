namespace P01_HospitalDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Patient
    {
        public Patient()
        {
            this.Visitations = new HashSet<Visitation>();
            this.Prescriptions = new HashSet<PatientMedicament>();
            this.Diagnoses = new HashSet<Diagnose>();
        }
        [Key]
        public int PatientId { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, MaxLength(250)]
        public string Address { get; set; }

        [Required, MaxLength(80)]
        public string Email { get; set; }

        [Required]
        public bool HasInsurance { get; set; }


        public virtual ICollection<PatientMedicament> Prescriptions { get; set; }
        public virtual ICollection<Visitation> Visitations { get; set; }
        public virtual ICollection<Diagnose> Diagnoses { get; set; }

    }
}

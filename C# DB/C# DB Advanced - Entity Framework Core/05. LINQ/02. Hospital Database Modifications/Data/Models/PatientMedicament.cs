namespace P01_HospitalDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PatientMedicament
    {
        [Required, ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Required, ForeignKey("Medicament")]
        public int MedicamentId { get; set; }
        public Medicament Medicament { get; set; }
    }
}

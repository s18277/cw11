using Microsoft.EntityFrameworkCore;

namespace Cw11.Models
{
    public class ClinicDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

        public ClinicDbContext() { }

        public ClinicDbContext(DbContextOptions options) : base(options) { }
    }
}
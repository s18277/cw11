using Cw11.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Cw11.Models
{
    public class ClinicDbContext : DbContext
    {
        public ClinicDbContext() { }

        public ClinicDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DoctorEfcConfiguration());
            modelBuilder.ApplyConfiguration(new PatientEfcConfiguration());
            modelBuilder.ApplyConfiguration(new PrescriptionEfcConfiguration());
            modelBuilder.ApplyConfiguration(new MedicamentEfcConfiguration());
            modelBuilder.ApplyConfiguration(new PrescriptionMedicamentEfcConfiguration());
        }
    }
}
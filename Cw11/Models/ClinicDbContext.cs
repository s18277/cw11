using System;
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
            SeedDataToDb(modelBuilder);
        }

        private static void SeedDataToDb(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor {IdDoctor = 1, FirstName = "Paweł", LastName = "Rutkowski", Email = "email1@address.com"},
                new Doctor {IdDoctor = 2, FirstName = "Kamil", LastName = "Malicki", Email = "email2@address.com"}
            );
            modelBuilder.Entity<Patient>().HasData(
                new Patient {IdPatient = 1, FirstName = "Maciej", LastName = "Król", Birthdate = DateTime.Now},
                new Patient {IdPatient = 2, FirstName = "Andrzej", LastName = "Kowalski", Birthdate = DateTime.Now}
            );
            modelBuilder.Entity<Medicament>().HasData(
                new Medicament
                    {IdMedicament = 1, Name = "Polopiryna", Description = "Lek przeciwbólowy", Type = "Tabletki"},
                new Medicament
                    {IdMedicament = 2, Name = "Witamina C", Description = "Właściwie to na nic", Type = "Saszetka"}
            );
            modelBuilder.Entity<Prescription>().HasData(
                new Prescription
                {
                    IdPrescription = 1, Date = DateTime.Now, DueDate = DateTime.Now.AddMonths(1), IdDoctor = 1,
                    IdPatient = 1
                },
                new Prescription
                {
                    IdPrescription = 2, Date = DateTime.Now, DueDate = DateTime.Now.AddMonths(2), IdDoctor = 2,
                    IdPatient = 1
                }
            );
            modelBuilder.Entity<PrescriptionMedicament>().HasData(
                new PrescriptionMedicament {IdPrescription = 1, IdMedicament = 1, Dose = 1, Details = "Szczegóły 1"},
                new PrescriptionMedicament {IdPrescription = 1, IdMedicament = 2, Details = "Szczegóły 2"},
                new PrescriptionMedicament {IdPrescription = 2, IdMedicament = 1, Dose = 2, Details = "Szczegóły 3"}
            );
        }
    }
}
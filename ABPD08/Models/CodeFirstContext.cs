using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ABPD08.Models
{
    public class CodeFirstContext : DbContext
    {
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Medicament> Medicament { get; set; }

        public DbSet<Prescription> Prescription { get; set; }

        public DbSet<PresciptionMedicament> PresciptionMedicament { get; set; }

        public CodeFirstContext()
        {
        }

        public CodeFirstContext(DbContextOptions<CodeFirstContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s18902;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient).HasName("Patient_PK");

                entity.Property(e => e.IdPatient).ValueGeneratedNever();

                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Birthdate).IsRequired();
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor).HasName("Doctor_PK");

                entity.Property(e => e.IdDoctor).ValueGeneratedNever();

                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.IdMedicament).HasName("Medicament_PK");

                entity.Property(e => e.IdMedicament).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Type).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.IdPrescription).HasName("Prescription_PK");

                entity.Property(e => e.IdPrescription).ValueGeneratedNever();

                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.DueDate).IsRequired();

                entity.HasOne(p => p.Patient).WithMany(p => p.Prescriptions)
                    .HasForeignKey(p => p.IdPatient).OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Patient");

                entity.HasOne(p => p.Doctor).WithMany(d => d.Prescriptions)
                    .HasForeignKey(p => p.IdDoctor).HasConstraintName("Prescription_Doctor")
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PresciptionMedicament>(entity =>
            {
                entity.ToTable("Prescription_Medicament");

                entity.HasKey(e => new
                {
                    e.IdMedicament,
                    e.IdPrescription
                }).HasName("Prescription_Medicament_PK");

                entity.Property(e => e.Details).HasMaxLength(100).IsRequired();

                entity.HasOne(m => m.Medicament).WithMany(pm => pm.PresciptionMedicaments)
                    .HasForeignKey(m => m.IdMedicament).OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(p => p.Prescription).WithMany(mp => mp.PresciptionMedicaments)
                    .HasForeignKey(p => p.IdPrescription).OnDelete(DeleteBehavior.ClientSetNull);

            });


            var doctors = new List<Doctor>();
            doctors.Add(new Doctor
            {
                IdDoctor = 1,
                FirstName = "John",
                LastName = "Gabbana",
                Email = "johngabbana@gmail.com"
            });
            doctors.Add(new Doctor
            {
                IdDoctor = 2,
                FirstName = "Karol",
                LastName = "Nowak",
                Email = "karolNowak@gmail.com"
            });
            doctors.Add(new Doctor
            {
                IdDoctor = 3,
                FirstName = "Jan",
                LastName = "Kowalski",
                Email = "janKowalski@gmail.com"
            });

            var patients = new List<Patient>();
            patients.Add(new Patient
            {
                IdPatient = 1,
                FirstName = "Basia",
                LastName = "Ross",
                Birthdate = DateTime.Parse("1990-05-11")
            });
            patients.Add(new Patient
            {
                IdPatient = 2,
                FirstName = "Kevin",
                LastName = "Kostner",
                Birthdate = DateTime.Parse("1970-01-20")
            });
            patients.Add(new Patient
            {
                IdPatient = 3,
                FirstName = "Tim",
                LastName = "Cook",
                Birthdate = DateTime.Parse("1982-11-05")
            });

            var MedicamentsSeed = new List<Medicament>();
            MedicamentsSeed.Add(
                new Medicament()
                {
                    IdMedicament = 1,
                    Name = "Propranolol",
                    Description = "opis propranololu",
                    Type = "Healthy"
                }
            );
            MedicamentsSeed.Add(
                new Medicament()
                {
                    IdMedicament = 2,
                    Name = "Ibuprom",
                    Description = "opis Ibuprom",
                    Type = "Przeciwbolowy"
                }
            );
            MedicamentsSeed.Add(
                new Medicament()
                {
                    IdMedicament = 3,
                    Name = "Apap",
                    Description = "opis Apapu",
                    Type = "Przeciwbolowy"
                }
            );
            MedicamentsSeed.Add(
                new Medicament()
                {
                    IdMedicament = 4,
                    Name = "Apap",
                    Description = "opis Apapu",
                    Type = "Przeciwbolowy"
                }
            );
            MedicamentsSeed.Add(
                new Medicament()
                {
                    IdMedicament = 5,
                    Name = "Adderall",
                    Description = "opis Adderallu",
                    Type = "Szybki"
                }
            );

            var prescriptions = new List<Prescription>();
            prescriptions.Add(new Prescription
            {
                IdPrescription = 1,
                Date = DateTime.Today,
                DueDate = DateTime.Parse("2025-11-08"),
                IdPatient = 1,
                IdDoctor = 1
            });
            prescriptions.Add(new Prescription
            {
                IdPrescription = 2,
                Date = DateTime.Today,
                DueDate = DateTime.Parse("2024-01-12"),
                IdPatient = 2,
                IdDoctor = 3
            });
            prescriptions.Add(new Prescription
            {
                IdPrescription = 3,
                Date = DateTime.Today,
                DueDate = DateTime.Parse("2023-08-22"),
                IdPatient = 3,
                IdDoctor = 2
            });

            var presMeds = new List<PresciptionMedicament>();
            presMeds.Add(new PresciptionMedicament
            {
                IdMedicament = 1,
                IdPrescription = 1,
                Dose = 20,
                Details = "lorem"
            });
            presMeds.Add(new PresciptionMedicament
            {
                IdMedicament = 3,
                IdPrescription = 2,
                Details = "tessting"
            });
            presMeds.Add(new PresciptionMedicament
            {
                IdMedicament = 2,
                IdPrescription = 3,
                Dose = 11,
                Details = "yooooo"
            });

            modelBuilder.Entity<Medicament>().HasData(MedicamentsSeed);
            modelBuilder.Entity<Doctor>().HasData(doctors);
            modelBuilder.Entity<Patient>().HasData(patients);
            modelBuilder.Entity<Prescription>().HasData(prescriptions);
            modelBuilder.Entity<PresciptionMedicament>().HasData(presMeds);

        }
    }
}
﻿// <auto-generated />
using System;
using ABPD08.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ABPD08.Migrations
{
    [DbContext(typeof(CodeFirstContext))]
    partial class CodeFirstContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ABPD08.Models.Doctor", b =>
            {
                b.Property<int>("IdDoctor")
                    .HasColumnType("int");

                b.Property<string>("Email")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.Property<string>("FirstName")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.Property<string>("LastName")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.HasKey("IdDoctor")
                    .HasName("Doctor_PK");

                b.ToTable("Doctor");

                b.HasData(
                    new
                    {
                        IdDoctor = 1,
                        Email = "johngabbana@gmail.com",
                        FirstName = "John",
                        LastName = "Gabbana"
                    },
                    new
                    {
                        IdDoctor = 2,
                        Email = "karolNowak@gmail.com",
                        FirstName = "Karol",
                        LastName = "Nowak"
                    },
                    new
                    {
                        IdDoctor = 3,
                        Email = "janKowalski@gmail.com",
                        FirstName = "Jan",
                        LastName = "Kowalski"
                    });
            });

            modelBuilder.Entity("ABPD08.Models.Medicament", b =>
            {
                b.Property<int>("IdMedicament")
                    .HasColumnType("int");

                b.Property<string>("Description")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.Property<string>("Type")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.HasKey("IdMedicament")
                    .HasName("Medicament_PK");

                b.ToTable("Medicament");

                b.HasData(
                    new
                    {
                        IdMedicament = 1,
                        Description = "opis propranololu",
                        Name = "Propranolol",
                        Type = "Healthy"
                    },
                    new
                    {
                        IdMedicament = 2,
                        Description = "opis Ibuprom",
                        Name = "Ibuprom",
                        Type = "Przeciwbolowy"
                    },
                    new
                    {
                        IdMedicament = 3,
                        Description = "opis Apapu",
                        Name = "Apap",
                        Type = "Przeciwbolowy"
                    },
                    new
                    {
                        IdMedicament = 4,
                        Description = "opis Apapu",
                        Name = "Apap",
                        Type = "Przeciwbolowy"
                    },
                    new
                    {
                        IdMedicament = 5,
                        Description = "opis Adderallu",
                        Name = "Adderall",
                        Type = "Szybki"
                    });
            });

            modelBuilder.Entity("ABPD08.Models.Patient", b =>
            {
                b.Property<int>("IdPatient")
                    .HasColumnType("int");

                b.Property<DateTime>("Birthdate")
                    .HasColumnType("datetime2");

                b.Property<string>("FirstName")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.Property<string>("LastName")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.HasKey("IdPatient")
                    .HasName("Patient_PK");

                b.ToTable("Patient");

                b.HasData(
                    new
                    {
                        IdPatient = 1,
                        Birthdate = new DateTime(1990, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        FirstName = "Basia",
                        LastName = "Ross"
                    },
                    new
                    {
                        IdPatient = 2,
                        Birthdate = new DateTime(1970, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        FirstName = "Kevin",
                        LastName = "Kostner"
                    },
                    new
                    {
                        IdPatient = 3,
                        Birthdate = new DateTime(1982, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        FirstName = "Tim",
                        LastName = "Cook"
                    });
            });

            modelBuilder.Entity("ABPD08.Models.PresciptionMedicament", b =>
            {
                b.Property<int>("IdMedicament")
                    .HasColumnType("int");

                b.Property<int>("IdPrescription")
                    .HasColumnType("int");

                b.Property<string>("Details")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.Property<int>("Dose")
                    .HasColumnType("int");

                b.HasKey("IdMedicament", "IdPrescription")
                    .HasName("Prescription_Medicament_PK");

                b.HasIndex("IdPrescription");

                b.ToTable("Prescription_Medicament");

                b.HasData(
                    new
                    {
                        IdMedicament = 1,
                        IdPrescription = 1,
                        Details = "lorem",
                        Dose = 20
                    },
                    new
                    {
                        IdMedicament = 3,
                        IdPrescription = 2,
                        Details = "tessting",
                        Dose = 0
                    },
                    new
                    {
                        IdMedicament = 2,
                        IdPrescription = 3,
                        Details = "yooooo",
                        Dose = 11
                    });
            });

            modelBuilder.Entity("ABPD08.Models.Prescription", b =>
            {
                b.Property<int>("IdPrescription")
                    .HasColumnType("int");

                b.Property<DateTime>("Date")
                    .HasColumnType("datetime2");

                b.Property<DateTime>("DueDate")
                    .HasColumnType("datetime2");

                b.Property<int>("IdDoctor")
                    .HasColumnType("int");

                b.Property<int>("IdPatient")
                    .HasColumnType("int");

                b.HasKey("IdPrescription")
                    .HasName("Prescription_PK");

                b.HasIndex("IdDoctor");

                b.HasIndex("IdPatient");

                b.ToTable("Prescription");

                b.HasData(
                    new
                    {
                        IdPrescription = 1,
                        Date = new DateTime(2020, 5, 19, 0, 0, 0, 0, DateTimeKind.Local),
                        DueDate = new DateTime(2020, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        IdDoctor = 1,
                        IdPatient = 1
                    },
                    new
                    {
                        IdPrescription = 2,
                        Date = new DateTime(2020, 5, 19, 0, 0, 0, 0, DateTimeKind.Local),
                        DueDate = new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        IdDoctor = 3,
                        IdPatient = 2
                    },
                    new
                    {
                        IdPrescription = 3,
                        Date = new DateTime(2020, 5, 19, 0, 0, 0, 0, DateTimeKind.Local),
                        DueDate = new DateTime(2020, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        IdDoctor = 2,
                        IdPatient = 3
                    });
            });

            modelBuilder.Entity("ABPD08.Models.PresciptionMedicament", b =>
            {
                b.HasOne("ABPD08.Models.Medicament", "Medicament")
                    .WithMany("PresciptionMedicaments")
                    .HasForeignKey("IdMedicament")
                    .IsRequired();

                b.HasOne("ABPD08.Models.Prescription", "Prescription")
                    .WithMany("PresciptionMedicaments")
                    .HasForeignKey("IdPrescription")
                    .IsRequired();
            });

            modelBuilder.Entity("ABPD08.Models.Prescription", b =>
            {
                b.HasOne("ABPD08.Models.Doctor", "Doctor")
                    .WithMany("Prescriptions")
                    .HasForeignKey("IdDoctor")
                    .HasConstraintName("Prescription_Doctor")
                    .IsRequired();

                b.HasOne("ABPD08.Models.Patient", "Patient")
                    .WithMany("Prescriptions")
                    .HasForeignKey("IdPatient")
                    .HasConstraintName("Prescription_Patient")
                    .IsRequired();
            });
#pragma warning restore 612, 618
        }
    }
}

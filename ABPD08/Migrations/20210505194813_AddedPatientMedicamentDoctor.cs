using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ABPD08.Migrations
{
    public partial class AddedPatientMedicamentDoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    IdDoctor = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Doctor_PK", x => x.IdDoctor);
                });

            migrationBuilder.CreateTable(
                name: "Medicament",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Medicament_PK", x => x.IdMedicament);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    IdPatient = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Patient_PK", x => x.IdPatient);
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "johngabbana@gmail.com", "John", "Gabbana" },
                    { 2, "karolNowak@gmail.com", "Karol", "Nowak" },
                    { 3, "janKowalski@gmail.com", "Jan", "Kowalski" }
                });

            migrationBuilder.InsertData(
                table: "Medicament",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "opis propranololu", "Propranolol", "Healthy" },
                    { 2, "opis Ibuprom", "Ibuprom", "Przeciwbolowy" },
                    { 3, "opis Apapu", "Apap", "Przeciwbolowy" },
                    { 4, "opis Apapu", "Apap", "Przeciwbolowy" },
                    { 5, "opis Adderallu", "Adderall", "Szybki" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basia", "Ross" },
                    { 2, new DateTime(1970, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kevin", "Kostner" },
                    { 3, new DateTime(1982, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tim", "Cook" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Medicament");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}

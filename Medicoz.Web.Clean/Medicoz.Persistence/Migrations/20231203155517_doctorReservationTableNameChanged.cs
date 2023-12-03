using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medicoz.Persistence.Migrations
{
    public partial class doctorReservationTableNameChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorReservation");

            migrationBuilder.CreateTable(
                name: "DoctorAppointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    DoctorScheduleId = table.Column<int>(type: "int", nullable: false),
                    PasentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasentPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasentEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasentNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorAppointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorAppointment_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DoctorAppointment_DoctorSchedules_DoctorScheduleId",
                        column: x => x.DoctorScheduleId,
                        principalTable: "DoctorSchedules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorAppointment_DoctorId",
                table: "DoctorAppointment",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorAppointment_DoctorScheduleId",
                table: "DoctorAppointment",
                column: "DoctorScheduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorAppointment");

            migrationBuilder.CreateTable(
                name: "DoctorReservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    DoctorScheduleId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PasentEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasentNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasentPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorReservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorReservation_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DoctorReservation_DoctorSchedules_DoctorScheduleId",
                        column: x => x.DoctorScheduleId,
                        principalTable: "DoctorSchedules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorReservation_DoctorId",
                table: "DoctorReservation",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorReservation_DoctorScheduleId",
                table: "DoctorReservation",
                column: "DoctorScheduleId");
        }
    }
}

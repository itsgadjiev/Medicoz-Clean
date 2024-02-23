using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medicoz.Persistence.Migrations
{
    public partial class AppointmentStatus_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppointmentStatus",
                table: "DoctorAppointment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentStatus",
                table: "DoctorAppointment");
        }
    }
}

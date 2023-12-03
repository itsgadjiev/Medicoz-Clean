using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medicoz.Persistence.Migrations
{
    public partial class doctorschedule_changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReserved",
                table: "DoctorSchedules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ReservingUserID",
                table: "DoctorSchedules",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReserved",
                table: "DoctorSchedules");

            migrationBuilder.DropColumn(
                name: "ReservingUserID",
                table: "DoctorSchedules");
        }
    }
}

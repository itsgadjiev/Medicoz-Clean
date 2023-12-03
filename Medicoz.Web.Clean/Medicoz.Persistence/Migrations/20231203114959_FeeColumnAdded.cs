using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medicoz.Persistence.Migrations
{
    public partial class FeeColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Fee",
                table: "Doctors",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fee",
                table: "Doctors");
        }
    }
}

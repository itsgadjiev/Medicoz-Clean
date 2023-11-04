using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medicoz.Persistence.Migrations
{
    public partial class sliders_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Sliders",
                newName: "Value");

            migrationBuilder.AddColumn<string>(
                name: "Culture",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Culture",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Sliders");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Sliders",
                newName: "Name");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medicoz.Identity.Migrations
{
    public partial class UserRoleAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abc43a8e-f7bb-8875-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "fc538825-e17a-4525-b1c5-7cea9ab2b3ed");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "55593074-b239-471d-85ff-06d5eabb10b6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "2ad68abd-79f9-4046-b2c6-7bc37c116ed7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e4ededa-484e-4c13-a547-b6147aa367e4", "AQAAAAEAACcQAAAAEAUGIUudIfpr9YGZBIWYuQum5it1LnQs8bMiwIjYED5cqUf3OHQDAwazqf+Khs49TQ==", "86095ad0-3ebd-47c7-bd16-107d2017ab7e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d41cad0b-7e44-439d-a04e-f8a11f73579e", "AQAAAAEAACcQAAAAEDZVEkR2upE5VCjXW/tDTFLmOhVEm7LC7u5ekysrk7F5jFT1v/gfICWWnCBOYHUIOQ==", "0abc0df8-3f1d-43e0-95ca-afe041cc3f78" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abc43a8e-f7bb-8875-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "7703fcd2-dbb8-437c-9c94-790ace499151");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "a9efc230-4706-4bec-9403-97224aeba60e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "0fc5230c-9e09-495f-8b17-1fb904d50d77");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39d79a00-8bdf-471a-830c-a1f5190d18f4", "AQAAAAEAACcQAAAAEL93iB6sUz3Gi9z/uTuOZSXr1s6nG+x2wqQYffTZMzT4p4iya1zhGmUcwSjr10Egug==", "8e129d44-05cc-4915-983c-d64acbc679c1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd370d94-fd82-43b1-9ddf-af3e69201196", "AQAAAAEAACcQAAAAEMAGGU36r+M1EB9UNhbzEktkti65qn/IMCdDEAGPdR14NXolBMKTy4PEo3/OhXG5QQ==", "6f0df329-6e95-4f10-af03-b48249bfec6d" });
        }
    }
}

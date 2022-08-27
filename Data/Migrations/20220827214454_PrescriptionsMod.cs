using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcApp.Data.Migrations
{
    public partial class PrescriptionsMod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "PrescriptionsModel");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "PrescriptionsModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "PrescriptionsModel");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "PrescriptionsModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

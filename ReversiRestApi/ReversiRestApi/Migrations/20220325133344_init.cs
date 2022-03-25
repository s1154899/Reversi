using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReversiRestApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Speler1",
                table: "Spellen");

            migrationBuilder.DropColumn(
                name: "Speler2",
                table: "Spellen");

            migrationBuilder.RenameColumn(
                name: "Aandebeurd",
                table: "Spellen",
                newName: "Speler2Token");

            migrationBuilder.AddColumn<string>(
                name: "AandeBeurt",
                table: "Spellen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Spellen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Speler1Token",
                table: "Spellen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AandeBeurt",
                table: "Spellen");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Spellen");

            migrationBuilder.DropColumn(
                name: "Speler1Token",
                table: "Spellen");

            migrationBuilder.RenameColumn(
                name: "Speler2Token",
                table: "Spellen",
                newName: "Aandebeurd");

            migrationBuilder.AddColumn<string>(
                name: "Speler1",
                table: "Spellen",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Speler2",
                table: "Spellen",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

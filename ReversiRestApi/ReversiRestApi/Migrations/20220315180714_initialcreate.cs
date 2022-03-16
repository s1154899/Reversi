using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReversiRestApi.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spelers",
                columns: table => new
                {
                    Token = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spelers", x => x.Token);
                });

            migrationBuilder.CreateTable(
                name: "Spellen",
                columns: table => new
                {
                    Token = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Omschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Speler1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NavigationProperty1Token = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Speler2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NavigationProperty2Token = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Aandebeurd = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spellen", x => x.Token);
                    table.ForeignKey(
                        name: "FK_Spellen_Spelers_NavigationProperty1Token",
                        column: x => x.NavigationProperty1Token,
                        principalTable: "Spelers",
                        principalColumn: "Token");
                    table.ForeignKey(
                        name: "FK_Spellen_Spelers_NavigationProperty2Token",
                        column: x => x.NavigationProperty2Token,
                        principalTable: "Spelers",
                        principalColumn: "Token");
                });

            migrationBuilder.CreateTable(
                name: "Bord",
                columns: table => new
                {
                    Token = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SpelToken = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BespeeldBord = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bord", x => x.Token);
                    table.ForeignKey(
                        name: "FK_Bord_Spellen_SpelToken",
                        column: x => x.SpelToken,
                        principalTable: "Spellen",
                        principalColumn: "Token",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bord_SpelToken",
                table: "Bord",
                column: "SpelToken");

            migrationBuilder.CreateIndex(
                name: "IX_Spellen_NavigationProperty1Token",
                table: "Spellen",
                column: "NavigationProperty1Token");

            migrationBuilder.CreateIndex(
                name: "IX_Spellen_NavigationProperty2Token",
                table: "Spellen",
                column: "NavigationProperty2Token");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bord");

            migrationBuilder.DropTable(
                name: "Spellen");

            migrationBuilder.DropTable(
                name: "Spelers");
        }
    }
}

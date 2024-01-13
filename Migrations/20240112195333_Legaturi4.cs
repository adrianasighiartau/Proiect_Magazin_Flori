using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Magazin_Flori.Migrations
{
    public partial class Legaturi4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    SiteUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Oras = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Strada = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresa", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Adresa_AspNetUsers_SiteUserId",
                        column: x => x.SiteUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Floare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Culoare = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pret = table.Column<double>(type: "float", nullable: false),
                    Stoc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floare", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    SiteUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FloareID = table.Column<int>(type: "int", nullable: true),
                    Cantitate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cos_AspNetUsers_SiteUserId",
                        column: x => x.SiteUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cos_Floare_FloareID",
                        column: x => x.FloareID,
                        principalTable: "Floare",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresa_SiteUserId",
                table: "Adresa",
                column: "SiteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cos_FloareID",
                table: "Cos",
                column: "FloareID");

            migrationBuilder.CreateIndex(
                name: "IX_Cos_SiteUserId",
                table: "Cos",
                column: "SiteUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresa");

            migrationBuilder.DropTable(
                name: "Cos");

            migrationBuilder.DropTable(
                name: "Floare");
        }
    }
}

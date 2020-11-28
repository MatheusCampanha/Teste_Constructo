using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_Ex_3.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Condominios",
                columns: table => new
                {
                    Id_Condominio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condominios", x => x.Id_Condominio);
                });

            migrationBuilder.CreateTable(
                name: "Familias",
                columns: table => new
                {
                    Id_Familia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apto = table.Column<int>(type: "int", nullable: false),
                    Id_Condominio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familias", x => x.Id_Familia);
                    table.ForeignKey(
                        name: "FK_Familias_Condominios_Id_Condominio",
                        column: x => x.Id_Condominio,
                        principalTable: "Condominios",
                        principalColumn: "Id_Condominio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Moradors",
                columns: table => new
                {
                    Id_Morador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QtdBichos = table.Column<int>(type: "int", nullable: false),
                    Id_Familia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moradors", x => x.Id_Morador);
                    table.ForeignKey(
                        name: "FK_Moradors_Familias_Id_Familia",
                        column: x => x.Id_Familia,
                        principalTable: "Familias",
                        principalColumn: "Id_Familia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Familias_Id_Condominio",
                table: "Familias",
                column: "Id_Condominio");

            migrationBuilder.CreateIndex(
                name: "IX_Moradors_Id_Familia",
                table: "Moradors",
                column: "Id_Familia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moradors");

            migrationBuilder.DropTable(
                name: "Familias");

            migrationBuilder.DropTable(
                name: "Condominios");
        }
    }
}

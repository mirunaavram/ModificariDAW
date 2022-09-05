using Microsoft.EntityFrameworkCore.Migrations;

namespace test2.Migrations
{
    public partial class AddedTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tabela",
                columns: table => new
                {
                    IdTanar = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdActivitate = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    An = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabela", x => new { x.IdTanar, x.IdActivitate });
                    table.ForeignKey(
                        name: "FK_Tabela_Activitate_IdActivitate",
                        column: x => x.IdActivitate,
                        principalTable: "Activitate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tabela_Tineri_IdTanar",
                        column: x => x.IdTanar,
                        principalTable: "Tineri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tabela_IdActivitate",
                table: "Tabela",
                column: "IdActivitate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tabela");
        }
    }
}

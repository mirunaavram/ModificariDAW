using Microsoft.EntityFrameworkCore.Migrations;

namespace test2.Migrations
{
    public partial class AddedLocatie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locatie",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TanarId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Oras = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tara = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locatie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locatie_Tineri_TanarId",
                        column: x => x.TanarId,
                        principalTable: "Tineri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locatie_TanarId",
                table: "Locatie",
                column: "TanarId",
                unique: true,
                filter: "[TanarId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locatie");
        }
    }
}

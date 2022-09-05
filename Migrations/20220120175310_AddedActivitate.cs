using Microsoft.EntityFrameworkCore.Migrations;

namespace test2.Migrations
{
    public partial class AddedActivitate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activitate",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categorie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NrParticipanti = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activitate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PerioadaActivitate",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Luna = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    An = table.Column<int>(type: "int", nullable: false),
                    ActivitateId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerioadaActivitate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerioadaActivitate_Activitate_ActivitateId",
                        column: x => x.ActivitateId,
                        principalTable: "Activitate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerioadaActivitate_ActivitateId",
                table: "PerioadaActivitate",
                column: "ActivitateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerioadaActivitate");

            migrationBuilder.DropTable(
                name: "Activitate");
        }
    }
}

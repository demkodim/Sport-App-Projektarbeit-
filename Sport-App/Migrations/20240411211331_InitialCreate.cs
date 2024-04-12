using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sport_App.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nutzern",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Alter = table.Column<int>(type: "INTEGER", nullable: false),
                    Gewicht = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutzern", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sportarten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Zeit = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sportarten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainingsplaene",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NutzerID = table.Column<int>(type: "INTEGER", nullable: false),
                   
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainingsplaene", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainingsplaene_Nutzern_NutzerID",
                        column: x => x.NutzerID,
                        principalTable: "Nutzern",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingsAufbauten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Anzahl = table.Column<int>(type: "INTEGER", nullable: false),
                    SportartID = table.Column<int>(type: "INTEGER", nullable: false),
                    TrainingsplanID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingsAufbauten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingsAufbauten_Sportarten_SportartID",
                        column: x => x.SportartID,
                        principalTable: "Sportarten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingsAufbauTrainingsplan",
                columns: table => new
                {
                    TrainingsAufbauId = table.Column<int>(type: "INTEGER", nullable: false),
                    TrainingsplansId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingsAufbauTrainingsplan", x => new { x.TrainingsAufbauId, x.TrainingsplansId });
                    table.ForeignKey(
                        name: "FK_TrainingsAufbauTrainingsplan_TrainingsAufbauten_TrainingsAufbauId",
                        column: x => x.TrainingsAufbauId,
                        principalTable: "TrainingsAufbauten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingsAufbauTrainingsplan_Trainingsplaene_TrainingsplansId",
                        column: x => x.TrainingsplansId,
                        principalTable: "Trainingsplaene",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingsAufbauten_SportartID",
                table: "TrainingsAufbauten",
                column: "SportartID");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingsAufbauTrainingsplan_TrainingsplansId",
                table: "TrainingsAufbauTrainingsplan",
                column: "TrainingsplansId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainingsplaene_NutzerID",
                table: "Trainingsplaene",
                column: "NutzerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingsAufbauTrainingsplan");

            migrationBuilder.DropTable(
                name: "TrainingsAufbauten");

            migrationBuilder.DropTable(
                name: "Trainingsplaene");

            migrationBuilder.DropTable(
                name: "Sportarten");

            migrationBuilder.DropTable(
                name: "Nutzern");
        }
    }
}

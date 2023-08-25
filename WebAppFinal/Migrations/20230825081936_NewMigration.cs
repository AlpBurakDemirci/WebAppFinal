using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppFinal.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kisiler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisiler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Okullar",
                columns: table => new
                {
                    SchoolId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SchoolName = table.Column<string>(type: "TEXT", nullable: false),
                    SchoolCity = table.Column<string>(type: "TEXT", nullable: false),
                    SchoolDistrict = table.Column<string>(type: "TEXT", nullable: false),
                    SchoolScore = table.Column<int>(type: "INTEGER", nullable: false),
                    KisiId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Okullar", x => x.SchoolId);
                    table.ForeignKey(
                        name: "FK_Okullar_Kisiler_KisiId",
                        column: x => x.KisiId,
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yiyecekler",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FoodName = table.Column<string>(type: "TEXT", nullable: false),
                    FoodType = table.Column<string>(type: "TEXT", nullable: false),
                    FoodCost = table.Column<int>(type: "INTEGER", nullable: false),
                    KisiId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yiyecekler", x => x.FoodId);
                    table.ForeignKey(
                        name: "FK_Yiyecekler_Kisiler_KisiId",
                        column: x => x.KisiId,
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Okullar_KisiId",
                table: "Okullar",
                column: "KisiId");

            migrationBuilder.CreateIndex(
                name: "IX_Yiyecekler_KisiId",
                table: "Yiyecekler",
                column: "KisiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Okullar");

            migrationBuilder.DropTable(
                name: "Yiyecekler");

            migrationBuilder.DropTable(
                name: "Kisiler");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Adopt1Dev.DAL.Migrations
{
    public partial class ChangeTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Tarif");

            migrationBuilder.AddColumn<int>(
                name: "TypeTarifId",
                table: "Tarif",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TypeTarif",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeTarif", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarif_TypeTarifId",
                table: "Tarif",
                column: "TypeTarifId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarif_TypeTarif_TypeTarifId",
                table: "Tarif",
                column: "TypeTarifId",
                principalTable: "TypeTarif",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarif_TypeTarif_TypeTarifId",
                table: "Tarif");

            migrationBuilder.DropTable(
                name: "TypeTarif");

            migrationBuilder.DropIndex(
                name: "IX_Tarif_TypeTarifId",
                table: "Tarif");

            migrationBuilder.DropColumn(
                name: "TypeTarifId",
                table: "Tarif");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Tarif",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}

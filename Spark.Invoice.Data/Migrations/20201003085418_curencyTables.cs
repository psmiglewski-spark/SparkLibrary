using Microsoft.EntityFrameworkCore.Migrations;

namespace Spark.Invoice.Data.Migrations
{
    public partial class curencyTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrencyTableId",
                table: "Currencies",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CurrencyTables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    table = table.Column<string>(nullable: true),
                    no = table.Column<string>(nullable: true),
                    effectiveDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyTables", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_CurrencyTableId",
                table: "Currencies",
                column: "CurrencyTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_CurrencyTables_CurrencyTableId",
                table: "Currencies",
                column: "CurrencyTableId",
                principalTable: "CurrencyTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_CurrencyTables_CurrencyTableId",
                table: "Currencies");

            migrationBuilder.DropTable(
                name: "CurrencyTables");

            migrationBuilder.DropIndex(
                name: "IX_Currencies_CurrencyTableId",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "CurrencyTableId",
                table: "Currencies");
        }
    }
}

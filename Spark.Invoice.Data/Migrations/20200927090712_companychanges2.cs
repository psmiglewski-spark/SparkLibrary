using Microsoft.EntityFrameworkCore.Migrations;

namespace Spark.Invoice.Data.Migrations
{
    public partial class companychanges2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyAddress");

            migrationBuilder.DropTable(
                name: "IdBankAccounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyAddress",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAddress", x => new { x.AddressId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_CompanyAddress_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyAddress_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdBankAccounts",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    BankAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdBankAccounts", x => new { x.CompanyId, x.BankAccountId });
                    table.ForeignKey(
                        name: "FK_IdBankAccounts_BankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdBankAccounts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAddress_CompanyId",
                table: "CompanyAddress",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_IdBankAccounts_BankAccountId",
                table: "IdBankAccounts",
                column: "BankAccountId");
        }
    }
}

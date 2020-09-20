using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spark.Invoice.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NIP = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Short_Name = table.Column<string>(nullable: true),
                    Client_Type = table.Column<int>(nullable: false),
                    Discount = table.Column<int>(nullable: false),
                    Payment_Method = table.Column<string>(nullable: true),
                    Phone_Number = table.Column<string>(nullable: true),
                    Mobile_Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    WWW = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    currency = table.Column<string>(nullable: true),
                    code = table.Column<string>(nullable: true),
                    mid = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address_Street = table.Column<string>(nullable: true),
                    Address_Pos_Number = table.Column<string>(nullable: true),
                    Address_Loc_Number = table.Column<string>(nullable: true),
                    Address_Postal_Code = table.Column<string>(nullable: true),
                    Address_City = table.Column<string>(nullable: true),
                    Address_Country = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Addresses_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(nullable: true),
                    VatAccountNumber = table.Column<string>(nullable: true),
                    SWIFT = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Invoice_Number = table.Column<string>(nullable: true),
                    ID_Client = table.Column<int>(nullable: false),
                    Issue_Date = table.Column<DateTime>(nullable: false),
                    Sale_Date = table.Column<DateTime>(nullable: false),
                    Payment_Date = table.Column<DateTime>(nullable: false),
                    Payment_Method = table.Column<string>(nullable: true),
                    Payment_AccountID = table.Column<int>(nullable: true),
                    SplitPayment = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    Net_Value = table.Column<float>(nullable: false),
                    Gross_Value = table.Column<float>(nullable: false),
                    VAT_Value = table.Column<float>(nullable: false),
                    VAT = table.Column<float>(nullable: false),
                    Issuing_User = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    Currency_Change_Rate = table.Column<float>(nullable: false),
                    Kwota_Slownie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_BankAccounts_Payment_AccountID",
                        column: x => x.Payment_AccountID,
                        principalTable: "BankAccounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CompanyId",
                table: "Addresses",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_CompanyId",
                table: "BankAccounts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_Payment_AccountID",
                table: "Invoices",
                column: "Payment_AccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}

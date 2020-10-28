using Microsoft.EntityFrameworkCore.Migrations;

namespace Spark.Invoice.Data.Migrations
{
    public partial class invoice_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kwota_Slownie",
                table: "Invoices");

            migrationBuilder.AddColumn<string>(
                name: "Company_City",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Company_Country",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Company_Full_Address",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Company_Name",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Company_Postal_Code",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Payment",
                table: "Invoices",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company_City",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Company_Country",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Company_Full_Address",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Company_Name",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Company_Postal_Code",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Payment",
                table: "Invoices");

            migrationBuilder.AddColumn<string>(
                name: "Kwota_Slownie",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

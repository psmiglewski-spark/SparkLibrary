using Microsoft.EntityFrameworkCore.Migrations;

namespace Spark.Invoice.Data.Migrations
{
    public partial class cc2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Billing_Address",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Billing_City",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Billing_Country",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Billing_Postal_Code",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Full_Address",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Full_Address",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Postal_Code",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Full",
                table: "Addresses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Full_Address",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Postal_Code",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Address_Full",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "Billing_Address",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Billing_City",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Billing_Country",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Billing_Postal_Code",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Full_Address",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

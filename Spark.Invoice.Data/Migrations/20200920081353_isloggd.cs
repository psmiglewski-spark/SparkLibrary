using Microsoft.EntityFrameworkCore.Migrations;

namespace Spark.Invoice.Data.Migrations
{
    public partial class isloggd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IsLogged",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Session = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsLogged", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndividualRights",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsLoggedId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualRights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualRights_IsLogged_IsLoggedId",
                        column: x => x.IsLoggedId,
                        principalTable: "IsLogged",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndividualRights_IsLoggedId",
                table: "IndividualRights",
                column: "IsLoggedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndividualRights");

            migrationBuilder.DropTable(
                name: "IsLogged");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceTitanBusinessObjects.Migrations
{
    public partial class removeNavRenameAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserService");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Users",
                newName: "City");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "Users",
                newName: "Address");

            migrationBuilder.CreateTable(
                name: "ApplicationUserService",
                columns: table => new
                {
                    ServicesServiceID = table.Column<int>(type: "int", nullable: false),
                    TechniciansUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserService", x => new { x.ServicesServiceID, x.TechniciansUserID });
                    table.ForeignKey(
                        name: "FK_ApplicationUserService_Services_ServicesServiceID",
                        column: x => x.ServicesServiceID,
                        principalTable: "Services",
                        principalColumn: "service_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserService_Users_TechniciansUserID",
                        column: x => x.TechniciansUserID,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserService_TechniciansUserID",
                table: "ApplicationUserService",
                column: "TechniciansUserID");
        }
    }
}

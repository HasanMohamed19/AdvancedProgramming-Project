using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceTitanBusinessObjects.Migrations
{
    public partial class Addedforeignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTechnicians_Services_ServiceID",
                table: "ServiceTechnicians");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTechnicians_Users_TechnicianUserID",
                table: "ServiceTechnicians");

            migrationBuilder.DropIndex(
                name: "IX_ServiceTechnicians_ServiceID",
                table: "ServiceTechnicians");

            migrationBuilder.DropIndex(
                name: "IX_ServiceTechnicians_TechnicianUserID",
                table: "ServiceTechnicians");

            migrationBuilder.DropColumn(
                name: "ServiceID",
                table: "ServiceTechnicians");

            migrationBuilder.DropColumn(
                name: "TechnicianUserID",
                table: "ServiceTechnicians");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTechnicians_ServicesId",
                table: "ServiceTechnicians",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTechnicians_TechniciansId",
                table: "ServiceTechnicians",
                column: "TechniciansId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTechnicians_Services_ServicesId",
                table: "ServiceTechnicians",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "service_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTechnicians_Users_TechniciansId",
                table: "ServiceTechnicians",
                column: "TechniciansId",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTechnicians_Services_ServicesId",
                table: "ServiceTechnicians");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTechnicians_Users_TechniciansId",
                table: "ServiceTechnicians");

            migrationBuilder.DropIndex(
                name: "IX_ServiceTechnicians_ServicesId",
                table: "ServiceTechnicians");

            migrationBuilder.DropIndex(
                name: "IX_ServiceTechnicians_TechniciansId",
                table: "ServiceTechnicians");

            migrationBuilder.AddColumn<int>(
                name: "ServiceID",
                table: "ServiceTechnicians",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TechnicianUserID",
                table: "ServiceTechnicians",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTechnicians_ServiceID",
                table: "ServiceTechnicians",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTechnicians_TechnicianUserID",
                table: "ServiceTechnicians",
                column: "TechnicianUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTechnicians_Services_ServiceID",
                table: "ServiceTechnicians",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "service_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTechnicians_Users_TechnicianUserID",
                table: "ServiceTechnicians",
                column: "TechnicianUserID",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

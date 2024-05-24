using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceTitanBusinessObjects.Migrations
{
    public partial class addedcompositekey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceTechnicians",
                table: "ServiceTechnicians");

            migrationBuilder.DropIndex(
                name: "IX_ServiceTechnicians_ServicesId",
                table: "ServiceTechnicians");

            migrationBuilder.DropColumn(
                name: "ServiceTechniciansId",
                table: "ServiceTechnicians");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceTechnicians",
                table: "ServiceTechnicians",
                columns: new[] { "ServicesId", "TechniciansId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceTechnicians",
                table: "ServiceTechnicians");

            migrationBuilder.AddColumn<int>(
                name: "ServiceTechniciansId",
                table: "ServiceTechnicians",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceTechnicians",
                table: "ServiceTechnicians",
                column: "ServiceTechniciansId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTechnicians_ServicesId",
                table: "ServiceTechnicians",
                column: "ServicesId");
        }
    }
}

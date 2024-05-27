using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceTitanBusinessObjects.Migrations
{
    public partial class Addedmorefieldsfordocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "document_name",
                table: "Documents",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "DocumentDescription",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceRequestId",
                table: "Documents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ServiceRequestId",
                table: "Documents",
                column: "ServiceRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_ServiceRequests_ServiceRequestId",
                table: "Documents",
                column: "ServiceRequestId",
                principalTable: "ServiceRequests",
                principalColumn: "request_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_ServiceRequests_ServiceRequestId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ServiceRequestId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DocumentDescription",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ServiceRequestId",
                table: "Documents");

            migrationBuilder.AlterColumn<string>(
                name: "document_name",
                table: "Documents",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);
        }
    }
}

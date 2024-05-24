using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceTitanBusinessObjects.Migrations
{
    public partial class addedseedingandnullability : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TechnicianId",
                table: "ServiceRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "ServiceRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "NotificationStatus",
                columns: new[] { "notification_status_id", "NotificationStatusName" },
                values: new object[,]
                {
                    { 1, "Unread" },
                    { 2, "Read" }
                });

            migrationBuilder.InsertData(
                table: "RequestStatus",
                columns: new[] { "request_status_id", "request_status" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "In Progress" },
                    { 3, "Completed" },
                    { 4, "Cancelled" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NotificationStatus",
                keyColumn: "notification_status_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NotificationStatus",
                keyColumn: "notification_status_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RequestStatus",
                keyColumn: "request_status_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RequestStatus",
                keyColumn: "request_status_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RequestStatus",
                keyColumn: "request_status_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RequestStatus",
                keyColumn: "request_status_id",
                keyValue: 4);

            migrationBuilder.AlterColumn<int>(
                name: "TechnicianId",
                table: "ServiceRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "ServiceRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}

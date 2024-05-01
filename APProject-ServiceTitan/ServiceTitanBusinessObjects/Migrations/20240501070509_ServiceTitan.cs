using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceTitanBusinessObjects.Migrations
{
    public partial class ServiceTitan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotificationStatus",
                columns: table => new
                {
                    notification_status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationStatusName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationStatus", x => x.notification_status_id);
                });

            migrationBuilder.CreateTable(
                name: "RequestStatus",
                columns: table => new
                {
                    request_status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    request_status = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestStatus", x => x.request_status_id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoleID1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_RoleID1",
                        column: x => x.RoleID1,
                        principalTable: "UserRoles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    category_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryManagerUserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.category_id);
                    table.ForeignKey(
                        name: "FK_Categories_Users_CategoryManagerUserID",
                        column: x => x.CategoryManagerUserID,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    document_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    document_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    document_upload_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    document_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    document_path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.document_id);
                    table.ForeignKey(
                        name: "FK_Documents_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Source = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    original_value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    current_value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.log_id);
                    table.ForeignKey(
                        name: "FK_Logs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    notification_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    notification_message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    notification_title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    notification_type = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    notification_status = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.notification_id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    service_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    service_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    service_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    service_price = table.Column<float>(type: "real", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.service_id);
                    table.ForeignKey(
                        name: "FK_Services_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRequests",
                columns: table => new
                {
                    request_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    request_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    request_price = table.Column<int>(type: "int", nullable: false),
                    request_date_needed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ServiceID = table.Column<int>(type: "int", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequests", x => x.request_id);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_RequestStatus_StatusID",
                        column: x => x.StatusID,
                        principalTable: "RequestStatus",
                        principalColumn: "request_status_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_Services_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "Services",
                        principalColumn: "service_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceUser",
                columns: table => new
                {
                    ServicesServiceID = table.Column<int>(type: "int", nullable: false),
                    TechniciansUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceUser", x => new { x.ServicesServiceID, x.TechniciansUserID });
                    table.ForeignKey(
                        name: "FK_ServiceUser_Services_ServicesServiceID",
                        column: x => x.ServicesServiceID,
                        principalTable: "Services",
                        principalColumn: "service_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceUser_Users_TechniciansUserID",
                        column: x => x.TechniciansUserID,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    comment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comment_text = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    comment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    ServiceRequestRequestID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.comment_id);
                    table.ForeignKey(
                        name: "FK_Comments_ServiceRequests_ServiceRequestRequestID",
                        column: x => x.ServiceRequestRequestID,
                        principalTable: "ServiceRequests",
                        principalColumn: "request_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryManagerUserID",
                table: "Categories",
                column: "CategoryManagerUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ServiceRequestRequestID",
                table: "Comments",
                column: "ServiceRequestRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserID",
                table: "Comments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_UserID",
                table: "Documents",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UserID",
                table: "Logs",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserID",
                table: "Notifications",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_ServiceID",
                table: "ServiceRequests",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_StatusID",
                table: "ServiceRequests",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_UserID",
                table: "ServiceRequests",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CategoryID",
                table: "Services",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceUser_TechniciansUserID",
                table: "ServiceUser",
                column: "TechniciansUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID1",
                table: "Users",
                column: "RoleID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "NotificationStatus");

            migrationBuilder.DropTable(
                name: "ServiceUser");

            migrationBuilder.DropTable(
                name: "ServiceRequests");

            migrationBuilder.DropTable(
                name: "RequestStatus");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserRoles");
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServiceTitanBusinessObjects;

#nullable disable

namespace ServiceTitanBusinessObjects.Migrations
{
    [DbContext(typeof(ServiceTitanDBContext))]
    [Migration("20240527072435_ Added more fields for document")]
    partial class Addedmorefieldsfordocument
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApplicationUserService", b =>
                {
                    b.Property<int>("ServicesServiceID")
                        .HasColumnType("int");

                    b.Property<int>("TechniciansUserID")
                        .HasColumnType("int");

                    b.HasKey("ServicesServiceID", "TechniciansUserID");

                    b.HasIndex("TechniciansUserID");

                    b.ToTable("ApplicationUserService");
                });

            modelBuilder.Entity("ServiceTitanBusinessObjects.ApplicationUser", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserID");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ServiceTitanBusinessObjects.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"), 1L, 1);

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("category_description");

                    b.Property<int?>("CategoryManagerId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("category_name");

                    b.HasKey("CategoryID");

                    b.HasIndex("CategoryManagerId")
                        .IsUnique()
                        .HasFilter("[CategoryManagerId] IS NOT NULL");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ServiceTitanBusinessObjects.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("comment_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentID"), 1L, 1);

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("comment_date");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("comment_text");

                    b.Property<int?>("ServiceRequestId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentID");

                    b.HasIndex("ServiceRequestId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ServiceTitanBusinessObjects.Document", b =>
                {
                    b.Property<int>("DocumentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("document_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentID"), 1L, 1);

                    b.Property<string>("DocumentDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("document_name");

                    b.Property<string>("DocumentPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("document_path");

                    b.Property<string>("DocumentType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("document_type");

                    b.Property<DateTime>("DocumentUploadDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("document_upload_date");

                    b.Property<int?>("ServiceRequestId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DocumentID");

                    b.HasIndex("ServiceRequestId");

                    b.HasIndex("UserId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("ServiceTitanBusinessObjects.Log", b =>
                {
                    b.Property<int>("LogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("log_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LogID"), 1L, 1);

                    b.Property<string>("CurrentValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("current_value");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginalValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("original_value");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LogID");

                    b.HasIndex("UserId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("ServiceTitanBusinessObjects.Notification", b =>
                {
                    b.Property<int>("NotificationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("notification_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationID"), 1L, 1);

                    b.Property<string>("NotificationMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("notification_message");

                    b.Property<int?>("NotificationStatusId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("NotificationTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("notification_title");

                    b.Property<string>("NotificationType")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("notification_type");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("NotificationID");

                    b.HasIndex("NotificationStatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("ServiceTitanBusinessObjects.NotificationStatus", b =>
                {
                    b.Property<int>("NotificationStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("notification_status_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationStatusID"), 1L, 1);

                    b.Property<string>("NotificationStatusName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("NotificationStatusID");

                    b.ToTable("NotificationStatus");

                    b.HasData(
                        new
                        {
                            NotificationStatusID = 1,
                            NotificationStatusName = "Unread"
                        },
                        new
                        {
                            NotificationStatusID = 2,
                            NotificationStatusName = "Read"
                        });
                });

            modelBuilder.Entity("ServiceTitanBusinessObjects.RequestStatus", b =>
                {
                    b.Property<int>("StatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("request_status_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusID"), 1L, 1);

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("request_status");

                    b.HasKey("StatusID");

                    b.ToTable("RequestStatus");

                    b.HasData(
                        new
                        {
                            StatusID = 1,
                            Status = "Pending"
                        },
                        new
                        {
                            StatusID = 2,
                            Status = "In Progress"
                        },
                        new
                        {
                            StatusID = 3,
                            Status = "Completed"
                        },
                        new
                        {
                            StatusID = 4,
                            Status = "Cancelled"
                        });
                });

            modelBuilder.Entity("ServiceTitanBusinessObjects.Service", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("service_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceID"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ServiceDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("service_description");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("service_name");

                    b.Property<decimal>("ServicePrice")
                        .HasPrecision(10, 3)
                        .HasColumnType("decimal(10,3)")
                        .HasColumnName("service_price");

                    b.HasKey("ServiceID");

                    b.HasIndex("CategoryId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("ServiceTitanBusinessObjects.ServiceRequest", b =>
                {
                    b.Property<int>("RequestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("request_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestID"), 1L, 1);

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestDateNeeded")
                        .HasColumnType("datetime2")
                        .HasColumnName("request_date_needed");

                    b.Property<string>("RequestDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("request_description");

                    b.Property<decimal>("RequestPrice")
                        .HasPrecision(10, 3)
                        .HasColumnType("decimal(10,3)")
                        .HasColumnName("request_price");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<int?>("TechnicianId")
                        .HasColumnType("int");

                    b.HasKey("RequestID");

                    b.HasIndex("ClientId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TechnicianId");

                    b.ToTable("ServiceRequests");
                });

            modelBuilder.Entity("ServiceTitanBusinessObjects.ServiceTechnician", b =>
                {
                    b.Property<int>("ServicesId")
                        .HasColumnType("int");

                    b.Property<int>("TechniciansId")
                        .HasColumnType("int");

                    b.HasKey("ServicesId", "TechniciansId");

                    b.HasIndex("TechniciansId");

                    b.ToTable("ServiceTechnicians");
                });

            modelBuilder.Entity("ServiceTitanBusinessObjects.UserRole", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"), 1L, 1);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("RoleID");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            RoleID = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleID = 2,
                            RoleName = "Manager"
                        },
                        new
                        {
                            RoleID = 3,
                            RoleName = "Technician"
                        },
                        new
                        {
                            RoleID = 4,
                            RoleName = "User"
                        });
                });

            modelBuilder.Entity("ApplicationUserService", b =>
                {
                    b.HasOne("ServiceTitanBusinessObjects.Service", null)
                        .WithMany()
                        .HasForeignKey("ServicesServiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServiceTitanBusinessObjects.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("TechniciansUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ServiceTitanBusinessObjects.ApplicationUser", b =>
                {
                    b.HasOne("ServiceTitanBusinessObjects.UserRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ServiceTitanBusinessObjects.Category", b =>
                {
                    b.HasOne("ServiceTitanBusinessObjects.ApplicationUser", "CategoryManager")
                        .WithOne("Category")
                        .HasForeignKey("ServiceTitanBusinessObjects.Category", "CategoryManagerId");

                    b.Navigation("CategoryManager");
                });

            modelBuilder.Entity("ServiceTitanBusinessObjects.Comment", b =>
                {
                    b.HasOne("ServiceTitanBusinessObjects.ServiceRequest", "ServiceRequest")
                        .WithMany("Comments")
                        .HasForeignKey("ServiceRequestId");

                    b.HasOne("ServiceTitanBusinessObjects.ApplicationUser", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("ServiceRequest");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ServiceTitanBusinessObjects.Document", b =>
                {
                    b.HasOne("ServiceTitanBusinessObjects.ServiceRequest", "Request")
                        .WithMany()
                        .HasForeignKey("ServiceRequestId");

                    b.HasOne("ServiceTitanBusinessObjects.ApplicationUser", "User")
                        .WithMany("Documents")
                        .HasForeignKey("UserId");

                    b.Navigation("Request");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ServiceTitanBusinessObjects.Log", b =>
                {
                    b.HasOne("ServiceTitanBusinessObjects.ApplicationUser", "User")
                        .WithMany("Logs")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ServiceTitanBusinessObjects.Notification", b =>
                {
                    b.HasOne("ServiceTitanBusinessObjects.NotificationStatus", "NotificationStatus")
                        .WithMany()
                        .HasForeignKey("NotificationStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServiceTitanBusinessObjects.ApplicationUser", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId");

                    b.Navigation("NotificationStatus");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ServiceTitanBusinessObjects.Service", b =>
                {
                    b.HasOne("ServiceTitanBusinessObjects.Category", "Category")
                        .WithMany("Services")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ServiceTitanBusinessObjects.ServiceRequest", b =>
                {
                    b.HasOne("ServiceTitanBusinessObjects.ApplicationUser", "Client")
                        .WithMany("ClientServiceRequests")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("ServiceTitanBusinessObjects.Service", "Service")
                        .WithMany("ServiceRequests")
                        .HasForeignKey("ServiceId");

                    b.HasOne("ServiceTitanBusinessObjects.RequestStatus", "Status")
                        .WithMany("ServiceRequests")
                        .HasForeignKey("StatusId");

                    b.HasOne("ServiceTitanBusinessObjects.ApplicationUser", "Technician")
                        .WithMany("TechnicianServiceRequests")
                        .HasForeignKey("TechnicianId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Client");

                    b.Navigation("Service");

                    b.Navigation("Status");

                    b.Navigation("Technician");
                });

            modelBuilder.Entity("ServiceTitanBusinessObjects.ServiceTechnician", b =>
                {
                    b.HasOne("ServiceTitanBusinessObjects.Service", "Service")
                        .WithMany("ServiceTechnicians")
                        .HasForeignKey("ServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServiceTitanBusinessObjects.ApplicationUser", "Technician")
                        .WithMany("ServiceTechnicians")
                        .HasForeignKey("TechniciansId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("Technician");
                });

            modelBuilder.Entity("ServiceTitanBusinessObjects.ApplicationUser", b =>
                {
                    b.Navigation("Category");

                    b.Navigation("ClientServiceRequests");

                    b.Navigation("Comments");

                    b.Navigation("Documents");

                    b.Navigation("Logs");

                    b.Navigation("Notifications");

                    b.Navigation("ServiceTechnicians");

                    b.Navigation("TechnicianServiceRequests");
                });

            modelBuilder.Entity("ServiceTitanBusinessObjects.Category", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("ServiceTitanBusinessObjects.RequestStatus", b =>
                {
                    b.Navigation("ServiceRequests");
                });

            modelBuilder.Entity("ServiceTitanBusinessObjects.Service", b =>
                {
                    b.Navigation("ServiceRequests");

                    b.Navigation("ServiceTechnicians");
                });

            modelBuilder.Entity("ServiceTitanBusinessObjects.ServiceRequest", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}

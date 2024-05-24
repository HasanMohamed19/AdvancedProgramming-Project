using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTitanBusinessObjects
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequestStatus>().HasData(
                new RequestStatus{ StatusID = 1, Status = "Pending" },
                new RequestStatus{ StatusID = 2, Status = "In Progress" },
                new RequestStatus{ StatusID = 3, Status = "Completed" },
                new RequestStatus{ StatusID = 4, Status = "Cancelled" }
            );
            modelBuilder.Entity<NotificationStatus>().HasData(
                new NotificationStatus { NotificationStatusID = 1, NotificationStatusName = "Unread"},
                new NotificationStatus { NotificationStatusID = 2, NotificationStatusName = "Read"}
            );
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { RoleID = 1, RoleName = "Admin" },
                new UserRole { RoleID = 2, RoleName = "Manager" },
                new UserRole { RoleID = 3, RoleName = "Technician" },
                new UserRole { RoleID = 4, RoleName = "User" }
            );

        }
    }
}

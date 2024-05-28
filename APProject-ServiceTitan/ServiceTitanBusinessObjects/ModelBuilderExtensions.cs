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
            //modelBuilder.Entity<ApplicationUser>().HasData(
            //    new ApplicationUser { UserEmail = "admin@test.com", FirstName = "System", LastName = "Admin", City = "System", PhoneNumber = "00000000", RoleId = 1 },
            //    new ApplicationUser { UserEmail = "manager@test.com", FirstName = "Mahdi", LastName = "Marhoon", City = "Zinj", PhoneNumber = "12345678", RoleId = 2 },
            //    new ApplicationUser { UserEmail = "tech1@test.com", FirstName = "Qassim", LastName = "Meer", City = "Riffa", PhoneNumber = "12345678", RoleId = 3 },
            //    new ApplicationUser { UserEmail = "tech2@test.com", FirstName = "Salman", LastName = "Mandi", City = "Isa Town", PhoneNumber = "12345678", RoleId = 3 },
            //    new ApplicationUser { UserEmail = "user1@test.com", FirstName = "Yousif", LastName = "Alhawaj", City = "Zinj", PhoneNumber = "12345678", RoleId = 4 },
            //    new ApplicationUser { UserEmail = "user2@test.com", FirstName = "Malik", LastName = "Yaseen", City = "Cave", PhoneNumber = "12345678", RoleId = 4 }
            //);
        }
    }
}

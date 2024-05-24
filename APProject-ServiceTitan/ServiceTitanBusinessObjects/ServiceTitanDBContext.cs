using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTitanBusinessObjects
{
    public class ServiceTitanDBContext : DbContext
    {
        public ServiceTitanDBContext() : base()
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceTechnician> ServiceTechnicians { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<RequestStatus> RequestStatus { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<NotificationStatus> NotificationStatus { get; set; }
        public DbSet<AppUsers> AppUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localDB)\MSSQLLocalDB;Initial Catalog=ServiceTitanDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Comment>()
                .HasOne(e => e.User)
                .WithMany(e => e.Comments)
                .OnDelete(DeleteBehavior.NoAction);

            // set decimal precision and scale
            var decimalProps = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => (System.Nullable.GetUnderlyingType(p.ClrType) ?? p.ClrType) == typeof(decimal));

            // for technicain and client
            modelBuilder.Entity<ServiceRequest>()
           .HasOne(u => u.Technician)
           .WithMany(a => a.TechnicianServiceRequests)
           .HasForeignKey(i => i.TechnicianId)
           .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ServiceRequest>()
           .HasOne(i => i.Client)
           .WithMany(u => u.ClientServiceRequests)
           .HasForeignKey(i => i.ClientId)
           .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ServiceTechnician>()
                .HasKey("ServicesId","TechniciansId");

            modelBuilder.Entity<ServiceTechnician>()
                .HasOne(i => i.Service)
                .WithMany(u => u.ServiceTechnicians)
                .HasForeignKey(f => f.ServicesId);

            modelBuilder.Entity<ServiceTechnician>()
                .HasOne(i => i.Technician)
                .WithMany(u => u.ServiceTechnicians)
                .HasForeignKey(f => f.TechniciansId);

            foreach (var property in decimalProps)
            {
                property.SetPrecision(10);
                property.SetScale(3);
            }

            modelBuilder.Seed();
        }
    }
}

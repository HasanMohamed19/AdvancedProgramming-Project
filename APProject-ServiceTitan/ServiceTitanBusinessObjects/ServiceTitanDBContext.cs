using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTitanBusinessObjects
{
    public class ServiceTitanDBContext : DbContext
    {

        public ServiceTitanDBContext(DbContextOptions<ServiceTitanDBContext> options) : base(options)
        {

        }
        public ServiceTitanDBContext() : base()
        {

        }



        public DbSet<ApplicationUser> Users { get; set; }
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
                .HasKey("ServicesId", "TechniciansId");

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


        //    public override int SaveChanges()
        //    {

        //        this.ChangeTracker.DetectChanges();

        //        this.ChangeTracker.DetectChanges();
        //        var added = this.ChangeTracker.Entries()
        //                    .Where(t => t.State == EntityState.Added)
        //                    .Select(t => t.Entity)
        //                    .ToArray();

        //        foreach (var entity in added)
        //        {
        //            //var track = entity as ITrack;
        //            Log log = new Log();
        //            log.Time = DateTime.Now;
        //            log.UserId = 1;
        //            log.Source = "forms";
        //            log.OriginalValue = "a";
        //            log.CurrentValue = "b";
        //            log.Message = "m";
        //        }

        //        var modified = this.ChangeTracker.Entries()
        //                    .Where(t => t.State == EntityState.Modified)
        //                    .Select(t => t.Entity)
        //                    .ToArray();

        //        foreach (var entity in modified)
        //        {
        //            Log log = new Log();
        //            log.Time = DateTime.Now;
        //            log.UserId = 1;
        //            log.Source = "forms";
        //            log.OriginalValue = "a";
        //            log.CurrentValue = "b";
        //            log.Message = "m";
        //        }

        //        return base.SaveChanges();
        //    }

        // wrapper method for save forms
        public int Save(IdentityUser user, string source, string? message)
        {
            // Detect changes
            ChangeTracker.DetectChanges();

            // Get added and modified entities
            var added = ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Added)
                .Select(t => t.Entity)
                .ToList();

            var modified = ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Modified)
                .Select(t => t.Entity)
                .ToList();

            var deleted = ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Deleted)
                .Select(t => t.Entity)
                .ToList();

            // Create and populate log entries
            var logs = new List<Log>();
            foreach (var entity in added)
            {
                logs.Add(CreateLog(entity, EntityState.Added, user, source, message));
            }
            foreach (var entity in modified)
            {
                logs.Add(CreateLog(entity, EntityState.Modified, user, source, message));
            }
            foreach (var entity in modified)
            {
                logs.Add(CreateLog(entity, EntityState.Deleted, user, source, message));
            }

            // Add logs to DbContext (assuming Logs DbSet exists)
            Logs.AddRange(logs);

            // Save changes (including logs)
            return SaveChanges();
        }

        // wrapper method for save web
        public int Save(ClaimsPrincipal user, string source, string? message)
        {
            // Detect changes
            ChangeTracker.DetectChanges();

            // Get added and modified entities
            var added = ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Added)
                .Select(t => t.Entity)
                .ToList();

            var modified = ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Modified)
                .Select(t => t.Entity)
                .ToList();

            var deleted = ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Deleted)
                .Select(t => t.Entity)
                .ToList();

            // Create and populate log entries
            var logs = new List<Log>();
            foreach (var entity in added)
            {
                logs.Add(CreateLog(entity, EntityState.Added, user, source, message));
            }
            foreach (var entity in modified)
            {
                logs.Add(CreateLog(entity, EntityState.Modified, user, source, message));
            }
            foreach (var entity in modified)
            {
                logs.Add(CreateLog(entity, EntityState.Deleted, user, source, message));
            }

            // Add logs to DbContext (assuming Logs DbSet exists)
            Logs.AddRange(logs);

            // Save changes (including logs)
            return SaveChanges();
        }

        // override method for saveAsync for web
        public async Task<int> SaveAsync(ClaimsPrincipal user, string source, string? message)
        {
            // Detect changes
            ChangeTracker.DetectChanges();

            // Get added and modified entities
            var added = ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Added)
                .Select(t => t.Entity)
                .ToList();

            var modified = ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Modified)
                .Select(t => t.Entity)
                .ToList();

            var deleted = ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Deleted)
                .Select(t => t.Entity)
                .ToList();

            // Create and populate log entries
            var logs = new List<Log>();
            foreach (var entity in added)
            {
                logs.Add(CreateLog(entity, EntityState.Added, user, source, message));
            }
            foreach (var entity in modified)
            {
                logs.Add(CreateLog(entity, EntityState.Modified, user, source, message));
            }
            foreach (var entity in deleted)
            {
                logs.Add(CreateLog(entity, EntityState.Deleted, user, source, message));
            }

            // Add logs to DbContext (assuming Logs DbSet exists)
            Logs.AddRange(logs);

            // Save changes (including logs)
            return await SaveChangesAsync();
        }

        // function to create new log object to be inserted
        private Log CreateLog(object entity, EntityState state, ClaimsPrincipal user, string source, string? message)
        {
            var propertyInfo = entity.GetType().GetProperties();
            string commonType = "AuditTrail";
            if (state  == EntityState.Added)
            {
                message ??= "Added to entity";
                return new Log
                {
                    Time = DateTime.Now,
                    UserId = Users.Single(u=>u.UserEmail == user.Identity.Name).UserID,
                    Source = source,
                    Message = message,
                    OriginalValue = "",
                    CurrentValue = GetEntityPropertyValues(entity, propertyInfo),
                    Type = commonType
                };
            }
            else if (state == EntityState.Modified)
            {
                message ??= "Modified entity";
                Log log = new Log
                {
                    Time = DateTime.Now,
                    UserId = Users.Single(u => u.UserEmail == user.Identity.Name).UserID,
                    Source = source,
                    Message = message,
                    Type = commonType
                };

                var entry = ChangeTracker.Entries().SingleOrDefault(e => e.Entity == entity);
                if (entry != null)
                {
                    IEnumerable<PropertyEntry> changedProperties = entry.Properties.Where(p => p.IsModified);
                    log.OriginalValue = GetOriginalPropertyValues(changedProperties);
                    log.CurrentValue = GetCurrentPropertyValues(changedProperties);
                }

                return log;
            }
            else if (state == EntityState.Deleted)
            {
                message ??= "Deleted from entity";
                return new Log
                {
                    Time = DateTime.Now,
                    UserId = Users.Single(u => u.UserEmail == user.Identity.Name).UserID,
                    Source = source,
                    Message = message,
                    OriginalValue = GetEntityPropertyValues(entity, propertyInfo),
                    CurrentValue = "",
                    Type = commonType
                };
            }
            message ??= "";
            return new Log
            {
                Time = DateTime.Now,
                UserId = Users.Single(u => u.UserEmail == user.Identity.Name).UserID,
                Source = source,
                Message = message,
                OriginalValue = "",
                CurrentValue = "",
                Type = commonType
            };
        }

        // function to create lob object ot be inserted for forms
        private Log CreateLog(object entity, EntityState state, IdentityUser user, string source, string? message)
        {
            var propertyInfo = entity.GetType().GetProperties();
            string commonType = "AuditTrail";
            if (state  == EntityState.Added)
            {
                message ??= "Added to entity";
                return new Log
                {
                    Time = DateTime.Now,
                    UserId = Users.Single(u => u.UserEmail == user.UserName).UserID,
                    Source = source,
                    Message = message,
                    OriginalValue = "",
                    CurrentValue = GetEntityPropertyValues(entity, propertyInfo),
                    Type = commonType
                };
            }
            else if (state == EntityState.Modified)
            {
                message ??= "Modified entity";
                Log log = new Log
                {
                    Time = DateTime.Now,
                    UserId = Users.Single(u => u.UserEmail == user.UserName).UserID,
                    Source = source,
                    Message = message,
                    Type = commonType
                };

                var entry = ChangeTracker.Entries().SingleOrDefault(e => e.Entity == entity);
                if (entry != null)
                {
                    IEnumerable<PropertyEntry> changedProperties = entry.Properties.Where(p => p.IsModified);
                    log.OriginalValue = GetOriginalPropertyValues(changedProperties);
                    log.CurrentValue = GetCurrentPropertyValues(changedProperties);
                }

                return log;
            }
            else if (state == EntityState.Deleted)
            {
                message ??= "Deleted from entity";
                return new Log
                {
                    Time = DateTime.Now,
                    UserId = Users.Single(u => u.UserEmail == user.UserName).UserID,
                    Source = source,
                    Message = message,
                    OriginalValue = GetEntityPropertyValues(entity, propertyInfo),
                    CurrentValue = "",
                    Type = commonType
                };
            }
            message ??= "";
            return new Log
            {
                Time = DateTime.Now,
                UserId = Users.Single(u => u.UserEmail == user.UserName).UserID,
                Source = source,
                Message = message,
                OriginalValue = "",
                CurrentValue = "",
                Type = commonType
            };
        }

        //functions to get current and original values
        private string GetOriginalPropertyValues(IEnumerable<PropertyEntry> properties)
        {
            var values = new List<string>();
            foreach (var prop in properties)
            {
                if (prop.OriginalValue != null)
                    values.Add(prop.OriginalValue.ToString());
            }
            return string.Join(", ", values);
        }
        private string GetCurrentPropertyValues(IEnumerable<PropertyEntry> properties)
        {
            var values = new List<string>();
            foreach (var prop in properties)
            {
                if (prop.CurrentValue != null)
                    values.Add(prop.CurrentValue.ToString());
            }
            return string.Join(", ", values);
        }

        private string GetEntityPropertyValues(object entity, PropertyInfo[] properties = null)
        {
            if (properties == null)
            {
                properties = entity.GetType().GetProperties();
            }

            var values = new List<string>();
            foreach (var prop in properties)
            {
                values.Add($"{prop.Name}: {prop.GetValue(entity)}");
            }
            return string.Join(", ", values);
        }

        // function to log exceptiops
        public void LogException(Exception ex, ClaimsPrincipal user, string source)
        {
            RollBack(); // rollback changes to allow saving log
            string message = (ex.Message + "\n" + ex.InnerException);
            if (message.Length > 4000)
                message = message.Substring(0, 3999);
            Log log = new Log
            {
                Time = DateTime.Now,
                UserId = Users.Single(u => u.UserEmail == user.Identity.Name).UserID,
                Source = source,
                OriginalValue = "",
                CurrentValue = "",
                Message = message,
                Type = "Exception"
            };
            Logs.Add(log);
            SaveChanges();
        }

        public void LogException(Exception ex, IdentityUser user, string source)
        {
            RollBack(); // rollback changes to allow saving log
            string message = (ex.Message + "\n" + ex.InnerException);
            if (message.Length > 4000)
                message = message.Substring(0, 3999);
            Log log = new Log
            {
                Time = DateTime.Now,
                UserId = Users.Single(u => u.UserEmail == user.UserName).UserID,
                Source = source,
                OriginalValue = "",
                CurrentValue = "",
                Message = message,
                Type = "Exception"
            };
            Logs.Add(log);
            SaveChanges();
        }

        // function to roll back changes in case of a failure
        public void RollBack()
        {
            var changedEntries = ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }
    }



}

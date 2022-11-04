using Intranet.Persistance.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Emit;

namespace Intranet.Persistance
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUserDTO>
    {
        public DbSet<InterestDTO> Interests { get; set; }
        public DbSet<DepartmentDTO> Departments { get; set; }
        public DbSet<ApplicationUserDTO> Users { get; set; }
        public DbSet<EmployeeInterest> EmployeeInterest { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedDepartment(builder);
            SeedUsers(builder);
            SeedRoles(builder);
            SeedUserRoles(builder);

            builder.Entity<DepartmentDTO>().HasKey(x => x.Id);
            builder.Entity<InterestDTO>().HasKey(x => x.Id);
            builder.Entity<ApplicationUserDTO>().HasOne(x => x.Department).WithMany(x => x.Users).HasForeignKey(x => x.DepartmentId);
            builder.Entity<EmployeeInterest>().HasKey(x => new { x.InterestId, x.EmployeeId });
            builder.Entity<EmployeeInterest>().HasOne(x => x.Interest).WithMany(x => x.EmployeeInterest).HasForeignKey(x => x.InterestId);
            builder.Entity<EmployeeInterest>().HasOne(x => x.Employee).WithMany(x => x.EmployeeInterest).HasPrincipalKey(x => x.UserId).HasForeignKey(x => x.EmployeeId);
        }
        private void SeedUsers(ModelBuilder builder)
        {
            ApplicationUserDTO user = new ApplicationUserDTO()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserId = 299999999,
                NormalizedEmail = "admin@gmail.com",
                Email = "admin@gmail.com",
                FirstName = "admin",
                LastName = "admin",
                Position = "",
                DepartmentId = 1,
            };
            PasswordHasher<ApplicationUserDTO> passwordHasher = new PasswordHasher<ApplicationUserDTO>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Admin*123");
            builder.Entity<ApplicationUserDTO>().HasData(user);
        }
        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "User", ConcurrencyStamp = "2", NormalizedName = "user" }
                );
        }
        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
                );
        }
        private void SeedDepartment(ModelBuilder builder)
        {
            builder.Entity<DepartmentDTO>().HasData(
                new DepartmentDTO { Id = 1, Name = "HR" });
        }
    }
}
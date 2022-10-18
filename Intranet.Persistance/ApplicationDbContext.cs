using Intranet.Persistance.Models;
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
            builder.Entity<DepartmentDTO>().HasKey(x => x.Id);
            base.OnModelCreating(builder);


            builder.Entity<InterestDTO>().HasKey(x => x.Id);
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserDTO>().HasOne(x => x.Department).WithMany(x => x.Users).HasForeignKey(x => x.DepartmentId);

            builder.Entity<EmployeeInterest>().HasKey(x => new { x.InterestId, x.EmployeeId });
            builder.Entity<EmployeeInterest>().HasOne(x => x.Interest).WithMany(x => x.EmployeeInterest).HasForeignKey(x => x.InterestId);
            builder.Entity<EmployeeInterest>().HasOne(x => x.Employee).WithMany(x => x.EmployeeInterest).HasPrincipalKey(x => x.UserId).HasForeignKey(x => x.EmployeeId);

        }
    }
}
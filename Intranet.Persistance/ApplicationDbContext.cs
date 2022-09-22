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

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<InterestDTO>().HasKey(x => x.Id);
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserDTO>().HasOne(x=>x.Department).WithMany(x=>x.Users).HasForeignKey(x=>x.DepartmentId);

        }
    }
}
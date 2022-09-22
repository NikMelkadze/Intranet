using Intranet.Persistance.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

            builder.Entity<ApplicationUserDTO>().HasOne(x => x.Department).WithOne(y => y.Head).HasForeignKey<DepartmentDTO>(z => z.HeadId);
            builder.Entity<ApplicationUserDTO>().ToTable("Users");
            builder.Entity<DepartmentDTO>().ToTable("Departments");
        }
    }
}
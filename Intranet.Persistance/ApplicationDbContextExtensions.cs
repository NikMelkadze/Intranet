using Intranet.Persistance.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Intranet.Persistance.Services;
using Intranet.Persistance.Contracts;
using Intranet.Persistance.Repositories;

namespace Intranet.Persistance
{
    public static class ApplicationDbContextExtensions
    {
        public static IServiceCollection InstallApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            //Database
            _ = services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnStr")));

            //Identity
            _ = services.AddIdentity<ApplicationUserDTO, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            _ = services.AddTransient<IRepository<InterestDTO>, InterestRepository>();
            _ = services.AddTransient<IRepository<ApplicationUserDTO>, EmployeeRepository>();
            _ = services.AddTransient<IRepository<DepartmentDTO>, DepartmentRepository>();
            _ = services.AddTransient<IRepository<EmployeeInterest>, EmployeeInterestRepository>();

            return services;
        }
    }
}

using Intranet.Persistance.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Intranet.Persistance.Services;
using Intranet.Persistance.Contracts;

namespace Intranet.Persistance
{
    public static class ApplicationDbContextExtensions
    {
        public static IServiceCollection InstallApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            //Database
            _ = services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnStr")));

            //Identity
            _ = services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            _ = services.AddTransient<IRepository<Interest>, InterestRepository>();

            return services;
        }
    }
}

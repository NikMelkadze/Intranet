using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Persistance
{
    public static class ApplicationDbContextExtensions
    {
        public static IServiceCollection InstallApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {

            _ = services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnStr")));

            return services;
        }
    }
}

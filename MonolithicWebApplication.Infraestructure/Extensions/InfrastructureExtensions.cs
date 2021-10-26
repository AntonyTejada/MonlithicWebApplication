using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MonolithicWebApplication.Infraestructure.Data;

namespace MonolithicWebApplication.Infraestructure.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddDatabaseProvider(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer("server=LAPTOP-VBJJ1N26;database=MonolithicBooks;trusted_connection=true;"));

            return services;
        }
    }
}

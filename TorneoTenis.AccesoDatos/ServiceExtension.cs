using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TorneoTenis.AccesoDatos
{
    public static class ServiceExtension
    {
        public static void AddDataAccessInfrastructure(this IServiceCollection service,IConfiguration configuration)
        {
            service.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString: configuration.GetConnectionString("DefaultConnection"),
                        sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                            sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);

                        });
            });
        }

    }
}

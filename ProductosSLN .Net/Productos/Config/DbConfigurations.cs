using Microsoft.EntityFrameworkCore;
using Productos.Models;

namespace Productos.Config
{
    public static class DbConfigurations
    {
        public static IServiceCollection SetDatabaseConfiguration(this IServiceCollection services)
        {
            //var connectionString = Environment.GetEnvironmentVariable(MyVaccineLiterals.CONNECTION_STRING);
            var connectionString = "Server=DESKTOP-8FTT8UL;Database=ProductosBD;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;";
            services.AddDbContext<ProductoDbContext>(options =>
                        options.UseSqlServer(
                                    connectionString
                                    )
                        );
            return services;
        }
    }
}

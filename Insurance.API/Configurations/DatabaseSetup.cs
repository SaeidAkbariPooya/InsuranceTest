using Insurance.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Insurance.API.Configurations
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            string connString = configuration.GetConnectionString("InsuranceConnection");

            services.AddDbContext<InsuranceDbContext>(options =>
            {
                options.UseSqlServer(connString,
                sqlServerOptionsAction: sqlOptions =>
                {
                    //sqlOptions.EnableRetryOnFailure();
                });
            });
        }
    }
}

using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Structure.Domain;

namespace Structure.Infrastructure.Extensions
{
    public static class DatabaseExtension
    {
        public static void AddDbContextExt(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnectionString");
            //var connectionString = configuration.GetValue<string>("connectionStrings:Server=MSI;Database=/*sampleapplication*/;user=sa;password=password123");

            services.AddDbContextPool<StructureDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnectionString"))
                .EnableSensitiveDataLogging();
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.ConfigureWarnings(builder =>
                {
                    builder.Ignore(CoreEventId.PossibleIncorrectRequiredNavigationWithQueryFilterInteractionWarning);
                });
            });

            Console.WriteLine(connectionString);
        }
    }
}

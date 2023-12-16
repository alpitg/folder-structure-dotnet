using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Structure.Domain.Entities;

namespace Structure.Infrastructure.Extensions
{
    public static class DatabaseExtension
    {
        public static void AddDbContextExt(this IServiceCollection services, IConfiguration configuration)
        {
            var defaultValue = configuration.GetSection("TenantSettings:Defaults");
            //var connectionString = configuration.GetValue<string>("connectionStrings:DbConnectionString");
            var connectionString = defaultValue["ConnectionString"];

            services.AddDbContext<StructureDbContext>(options =>
            {
                options.UseSqlServer(connectionString)
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

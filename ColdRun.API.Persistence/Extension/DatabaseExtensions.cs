using ColdRun.API.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ColdRun.API.Persistence.Extension
{
    public static class DatabaseExtensions
    {
        public static IServiceProvider UseDatabaseInitializer(this IServiceProvider services, IConfiguration configuration)
        {
            using var scope = services.CreateScope();

            using var context = scope.ServiceProvider.GetService<ColdRunDbContext>()!;
            // context.Database.GetDbConnection().ConnectionString = configuration.GetConnectionString();
            context.Database.Migrate();

            return services;
        }
    }
}

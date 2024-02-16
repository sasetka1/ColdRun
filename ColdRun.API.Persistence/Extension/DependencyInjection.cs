using ColdRun.API.Persistence.Models;
using ColdRun.API.Persistence.Services;
using ColdRun.API.Persistence.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ColdRun.API.Persistence.Extension
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterPersistenceDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(Constants.DatabaseConnection.ColdRunConnection);
            services.AddDbContext<ColdRunDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<ITruckDataService, TruckDataService>();
            return services;
        }
    }
}

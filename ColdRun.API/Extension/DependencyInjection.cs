using ColdRun.API.Persistence.Models;
using ColdRun.API.Services;
using ColdRun.API.Mappers;
using ColdRun.API.Models;
using ColdRun.API.Services.Interfaces;

namespace ColdRun.API.Extension
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterPresentationDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IDataValidatorService<Models.Truck, Models.Truck>, TruckValidatorService>();
            services.AddScoped<IMapper<Persistence.Models.Truck, Models.Truck>, TruckMapper>();
            services.AddScoped<IMapper<Models.Truck, Persistence.Models.Truck>, TruckEFMapper>();
            services.AddScoped<ITruckService, TruckService>();  

            return services;
        }
    }
}

using ColdRun.API.Persistence.Models;
using ColdRun.API.Services;
using ColdRun.API.Mappers;
using ColdRun.API.Models;

namespace ColdRun.API.Extension
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterPresentationDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            //            services.AddScoped<IDataValidatorService<Truck>, TruckValidatorService>();

            services.AddScoped<IMapper<Persistence.Models.Truck, Models.Truck>, TruckMapper>();
            services.AddScoped<IMapper<Models.Truck, Persistence.Models.Truck>, TruckEFMapper>();
            services.AddScoped<Services.Interfaces.ITruckService, TruckService>();

  

            return services;
        }
    }
}

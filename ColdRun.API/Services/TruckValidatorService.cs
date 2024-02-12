using ColdRun.API.Models;
using ColdRun.API.Services.Interfaces;
using OperationResult;

namespace ColdRun.API.Services
{
    public class TruckValidatorService : IDataValidatorService<Truck>
    {
        public Status<List<string>> ValidateEntity(Truck entity)
        {
            throw new NotImplementedException();
        }
    }
}

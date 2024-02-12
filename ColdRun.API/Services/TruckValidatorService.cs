using ColdRun.API.Models;
using ColdRun.API.Services.Interfaces;
using OperationResult;
using ColdRun.API.Extension;
using static OperationResult.Helpers;

namespace ColdRun.API.Services
{
    public class TruckValidatorService : IDataValidatorService<Truck, Truck>
    {
        public bool ValidateEntity( Truck currentEntity, Truck newEntity)
        {
           return currentEntity.Status.IsValidStatusTransition(newEntity.Status);
        }

    }
}

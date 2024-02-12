using ColdRun.API.Mappers;
using ColdRun.API.Models;
using ColdRun.API.Persistence.Services.Interfaces;
using ColdRun.API.Services.Interfaces;
using OperationResult;
using System.Data;
using static OperationResult.Helpers;

namespace ColdRun.API.Services
{
    public class TruckService : ITruckService
    {
        //private readonly IDataValidatorService<Truck> _validatorService;
        private readonly IMapper<Persistence.Models.Truck, Truck> _truckMapper;
        private readonly IMapper<Truck, Persistence.Models.Truck> _truckToEFMapper;
        private readonly ITruckDataService _dataService;

        public TruckService(IMapper<Persistence.Models.Truck, Truck> truckMapper, IMapper<Truck, Persistence.Models.Truck> truckToEFMapper, ITruckDataService dataService)
        {
            _truckMapper = truckMapper;
            _truckToEFMapper = truckToEFMapper;
            _dataService = dataService;
        }

        async Task<Status<string>> ITruckService.Create(Truck truck)
        {
            try
            {
                var mapTruck = _truckToEFMapper.Map(truck);
                return await _dataService.Create(mapTruck);
            }
            catch(Exception ex)
            {
                var message = $" Task<Status<string>> ITruckService.Create(Truck truck) {ex.Message}";
                return Error(message);
            }

        }

        async Task<Status<string>> ITruckService.Delete(string code)
        {
            try
            {
                var truckResult = await _dataService.Delete(code);

                if (truckResult.IsError)
                    throw new DataException(truckResult.Error);

                return Ok();

            }
            catch (Exception ex)
            {
                var message = $"Error calling Task<Status<string>> ITruckService.Delete(string code) {ex.Message}";
                return Error(message);
            }
        }

        async Task<Result<Truck?, string>> ITruckService.Get(string code)
        {
            try
            {
                var truckResult = await _dataService.Get(code);

                if (truckResult.IsError)
                    throw new DataException(truckResult.Error);

                if(truckResult.Value == null)
                    return null;

                var result = _truckMapper.Map(truckResult.Value);

                return Ok(result);

            }
            catch (Exception ex)
            {
                var message = $"Error calling Task<Result<Truck?, string>> ITruckService.Get(string code) {ex.Message}";
                return Error(message);
            }

        }

        Task<Result<PagedList<Truck>, string>> ITruckService.GetAll(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        async Task<Status<string>> ITruckService.Update(Truck truck)
        {
            try
            {
                var mapTruck = _truckToEFMapper.Map(truck);
                return await _dataService.Update(mapTruck);
            }
            catch (Exception ex)
            {
                var message = $" Task<Status<string>> ITruckService.Update(Truck truck) {ex.Message}";
                return Error(message);
            }
        }
    }
}

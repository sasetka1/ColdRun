using ColdRun.API.Extension;
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
        private readonly IMapper<Persistence.Models.Truck, Truck> _truckMapper;
        private readonly IMapper<Truck, Persistence.Models.Truck> _truckToEFMapper;
        private readonly ITruckDataService _dataService;
        private readonly IDataValidatorService<Truck, Truck> _validatorService;
        public TruckService(IMapper<Persistence.Models.Truck, Truck> truckMapper, IMapper<Truck, Persistence.Models.Truck> truckToEFMapper, ITruckDataService dataService, IDataValidatorService<Truck, Truck> validatorService)
        {
            _truckMapper = truckMapper;
            _truckToEFMapper = truckToEFMapper;
            _dataService = dataService;
            _validatorService = validatorService;
        }

        public async Task<Status<string>> Create(Truck truck)
        {
            try
            {
                var isValid = _validatorService.ValidateEntity(null, truck);

                if (isValid == false)
                {
                    return Error($"The status:{truck.Status} is not possible.");
                }

                var mapTruck = _truckToEFMapper.Map(truck);
                return await _dataService.Create(mapTruck);
            }
            catch(Exception ex)
            {
                var message = $" Task<Status<string>> ITruckService.Create(Truck truck) {ex.Message}";
                return Error(message);
            }

        }

        public async Task<Status<string>> Delete(string code)
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

        public async Task<Result<Truck?, string>> Get(string code)
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

        public async Task<Result<PagedList<Truck>, string>?> GetAll(string? name, string? status, string? sortBy, int pageNumber = 1, int pageSize = int.MaxValue)
        {
            try
            {
                var truckResult = await _dataService.GetAll(name, status, sortBy);

                if (truckResult.IsError)
                    throw new DataException(truckResult.Error);

                if (truckResult.Value == null)
                    return null;

                  var trucks = truckResult.Value;

                // total count
                var totalCount = trucks.Count();

                // apply pagination
                trucks = trucks.Paginate(pageNumber, pageSize);

                // map result
                var result = trucks.Select(x => _truckMapper.Map(x)).ToList();

                // get paginated list
                var pagedList = new PagedList<Truck>(result, totalCount, pageNumber, pageSize);

                // return list
                return Ok(pagedList);

            }
            catch (Exception ex)
            {
                var message = $"Error calling Task<Result<Truck?, string>> ITruckService.Get(string code) {ex.Message}";
                return Error(message);
            }

        }

        public async Task<Status<string>> Update(Truck truck)
        {
            try
            {      

                var currentTruck = await Get(truck.Code);

                if(currentTruck.IsError)
                {
                    return Error(currentTruck.Error);
                }

                var isValid = _validatorService.ValidateEntity(currentTruck.Value, truck);

                if(isValid == false)
                {
                    return Error($"The status:{truck.Status} is not possible.");
                }

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

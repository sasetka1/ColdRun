using ColdRun.API.Persistence.Models;
using ColdRun.API.Persistence.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OperationResult;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Xml.Serialization;
using static OperationResult.Helpers;

namespace ColdRun.API.Persistence.Services
{
    public class TruckDataService : ITruckDataService
    {
        private readonly ILogger<TruckDataService> _logger;
        private readonly ColdRunDbContext _coldRunDbContext;



        public TruckDataService(ILogger<TruckDataService> logger, ColdRunDbContext coldRunDbContext)
        {
            _logger = logger;
            _coldRunDbContext = coldRunDbContext;
        }

        public async Task<Status<string>> Create(Truck truck)
        {
           try
            {
                // Validate if the code is unique
                if (await _coldRunDbContext.Trucks.AnyAsync(t => t.Code == truck.Code))
                {
                    return Error("The code has already exist");
                }

                // Implement logic to create a new truck
                await _coldRunDbContext.AddAsync(truck);
                await _coldRunDbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
              
                var message = $"Error occurred calling Create(Truck truck).The code: ({truck.Code}). {ex.Message}";
                _logger.LogError(ex, message);

                return Error(message);
            }
        }
        

        public async Task<Status<string>> Delete(string code)
        {
            try
            {
                var remove = await _coldRunDbContext.Trucks.Where(x => x.Code == code).FirstOrDefaultAsync();
                if (remove is null)
                {
                    return Error("The code not exist");
                }

 
                _coldRunDbContext.Trucks.Remove(remove);
                await _coldRunDbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {

                var message = $"Error occurred calling Delete(string code).The code: ({code}). {ex.Message}";
                _logger.LogError(ex, message);

                return Error(message);
            }
        }

        public async Task<Result<Truck?, string>> Get(string code)
        {
            CultureInfo originalCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            try
            {

                var result = await _coldRunDbContext.Trucks.FirstOrDefaultAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {

                var message = $"Error occurred calling Get(string code).The code: ({code}). {ex.Message}";
                _logger.LogError(ex, message);

                return Error(message);
            }
            finally
            {
                CultureInfo.CurrentCulture = originalCulture;
            }
        }

        public async Task<Result<IEnumerable<Truck>, string>> GetAll(string? name = null, string? status = null , string? sortBy = null)
        {
            var query = _coldRunDbContext.Trucks.AsQueryable();

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(t => t.Status == status);
            }

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(t => t.Name == name);
            }

            switch (sortBy?.ToLower())
            {
                case "code":
                    query = query.OrderBy(t => t.Code);
                    break;
                case "name":
                    query = query.OrderBy(t => t.Name);
                    break;
                default:
                    // Default sorting logic
                    query = query.OrderBy(t => t.Name);
                    break;
            }

            return await query.ToListAsync();
        }

        public async Task<Status<string>> Update(Truck truck)
        {
            try
            {
                // Validate if the code is unique
                if (await _coldRunDbContext.Trucks.AnyAsync(t => t.Code == truck.Code) == false)
                {
                    return Error("The code not exist");
                }

                // Implement logic to update a  truck
                _coldRunDbContext.Trucks.Update(truck);
                await _coldRunDbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {

                var message = $"Error occurred calling Update(Truck truck).The code: ({truck.Code}). {ex.Message}";
                _logger.LogError(ex, message);

                return Error(message);
            }
        }
    }
}

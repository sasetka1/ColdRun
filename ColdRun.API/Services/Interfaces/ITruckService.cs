using ColdRun.API.Models;
using OperationResult;
using System.Diagnostics.Metrics;

namespace ColdRun.API.Services.Interfaces
{
    public interface ITruckService
    {
        Task<Result<PagedList<Truck>, string>> GetAll(int pageNumber = 1, int pageSize = int.MaxValue);

        /// <summary>
        /// Returns a single Truck by code, if it exists, Otherwise returns null
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<Result<Truck?, string>> Get(string code);
        Task<Status<string>> Update(Truck truck);
        Task<Status<string>> Delete(string code);
        Task<Status<string>> Create(Truck truck);


    }
}


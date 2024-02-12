using ColdRun.API.Models;
using OperationResult;
using System.Diagnostics.Metrics;

namespace ColdRun.API.Services.Interfaces
{
    public interface ITruckService
    {
        public Task<Result<PagedList<Truck?>, string>?> GetAll(string name, string status, string sortBy, int pageNumber = 1, int pageSize = int.MaxValue);

        /// <summary>
        /// Returns a single Truck by code, if it exists, Otherwise returns null
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<Result<Truck?, string>> Get(string code);
        public Task<Status<string>> Update(Truck truck);
        public Task<Status<string>> Delete(string code);
        public Task<Status<string>> Create(Truck truck);


    }
}


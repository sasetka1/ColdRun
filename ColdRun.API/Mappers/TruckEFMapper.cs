using ColdRun.API.Models;

namespace ColdRun.API.Mappers
{
    public class TruckEFMapper : IMapper<Truck, Persistence.Models.Truck>
    {
        public Persistence.Models.Truck Map(Truck obj)
        {
            return new Persistence.Models.Truck() { 
                Code = obj.Code, 
                Name = obj.Name, 
                Description = obj.Description, 
                Status = obj.Status.ToString()};
        }
    }
}

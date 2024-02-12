using ColdRun.API.Models;

namespace ColdRun.API.Mappers
{
    public class TruckMapper : IMapper<Persistence.Models.Truck, Truck>
    {
        public Truck Map(Persistence.Models.Truck obj)
        {
            Enum.TryParse(obj.Status, out TruckStatus parsedStatus);

            return new Truck() { 
                Code = obj.Code,
                Name = obj.Name, 
                Status = parsedStatus,
                Description = obj.Description
            };
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ColdRun.API.Models
{
    public record Truck
    {
        [Required]
        public string Code { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public TruckStatus Status { get; set; } = TruckStatus.OutOfService;
        public string? Description { get; set; }
    }
}

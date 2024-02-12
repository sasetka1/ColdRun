using System.ComponentModel.DataAnnotations;

namespace ColdRun.API.Models
{
    public record Truck
    {
        [Required]
        public string? Code { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public TruckStatus? Status { get; set; }
        public string? Description { get; set; }
    }
}

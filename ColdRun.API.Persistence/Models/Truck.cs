using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColdRun.API.Persistence.Models
{
    public class Truck
    {
        [Key]
        [Required]
        [MaxLength(30)]
        public string? Code { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Status { get; set; }
        public string? Description { get; set; }
    }
}

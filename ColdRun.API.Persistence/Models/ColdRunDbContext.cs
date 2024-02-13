using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace ColdRun.API.Persistence.Models
{
    public class ColdRunDbContext : DbContext
    {
        public DbSet<Truck> Trucks { get; set; }
        private readonly IConfiguration _configuration;

        public ColdRunDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString(Constants.DatabaseConnection.ColdRunConnection);
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using FormulaOneV2.Shared.Models;

namespace FormulaOneV2.Server.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Driver> Drives { get; set; }
    }
}

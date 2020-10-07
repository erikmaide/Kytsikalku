using Microsoft.EntityFrameworkCore;
using KytsiKalku.Models;

namespace KytsiKalku.Data
{
    public class KytsiKalkuFuelContext : DbContext
    {
        public KytsiKalkuFuelContext(DbContextOptions<KytsiKalkuFuelContext> options)
            : base(options)
        {
        }

        public DbSet<FuelData> FuelData { get; set; }
    }
}
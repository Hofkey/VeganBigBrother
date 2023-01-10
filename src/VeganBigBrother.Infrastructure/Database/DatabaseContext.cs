using Microsoft.EntityFrameworkCore;
using VeganBigBrother.Core.Entities;

namespace VeganBigBrother.Infrastructure.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<SensorPart> SensorParts { get; set; }
        public DbSet<SensorSensorPart> SensorPartParts { get; set; }
        public DbSet<SensorPartReading> SensorPartReadings { get; set; }
        public DbSet<Location> Locations { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    }
}

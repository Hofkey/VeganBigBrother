using System.ComponentModel.DataAnnotations;
using VeganBigBrother.Core.Entities;
using VeganBigBrother.Core.Enums;

namespace VeganBigBrother.Core.Aggregates
{
    /// <summary>
    /// This class is an aggregat of sensor data.
    /// Data here comes from the Sensor, SensorPart, and Location tables.
    /// </summary>
    public class SensorAggregate
    {
        public SensorAggregate() { }

        /// <summary>
        /// Construct a sensor aggregate based on an existing sensor.
        /// </summary>
        /// <param name="sensor">The existing sensor</param>
        public SensorAggregate(Sensor sensor) 
        { 
            Id = sensor.Id;
            Name = sensor.Name;
            Location = sensor.Location;
            Type = sensor.Type;
        }

        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Sensor name required!")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Sensor type required!")]
        public SensorType Type { get; set; }

        [Required(ErrorMessage = "Sensor location required!")]
        public Location? Location { get; set; }

        [Required(ErrorMessage = "Sensor parts are required!")]
        [MinLength(1, ErrorMessage = "Sensor must have at least 1 part!")]
        public List<SensorPart> SensorParts { get; set; } = new List<SensorPart>();
    }
}

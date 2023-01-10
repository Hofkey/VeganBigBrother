using System.ComponentModel.DataAnnotations;
using VeganBigBrother.Core.Enums;

namespace VeganBigBrother.API.Models
{
    public class SensorPOCO
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Sensor part requires a name!")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Sensor part requires a type!")]
        public SensorType Type { get; set; }

        [Required(ErrorMessage = "Sensor location is required!")]
        public LocationPOCO? Location { get; set; }

        [Required(ErrorMessage = "Sensor parts are required!")]
        [MinLength(1, ErrorMessage = "Sensor must have at least 1 part!")]
        public List<SensorPartPOCO> sensorParts { get; set; } = new List<SensorPartPOCO>();
    }
}

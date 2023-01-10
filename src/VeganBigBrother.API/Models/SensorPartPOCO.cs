using System.ComponentModel.DataAnnotations;
using VeganBigBrother.Core.Enums;

namespace VeganBigBrother.API.Models
{
    public class SensorPartPOCO
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Sensor part requires a name!")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Sensor part requires a type!")]
        public SensorPartType Type { get; set; }

        public List<SensorPartReadingPOCO> sensorPartReadings { get; set; } = new List<SensorPartReadingPOCO>();
    }
}

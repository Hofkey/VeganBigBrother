using System.ComponentModel.DataAnnotations;
using VeganBigBrother.Core.Enums;

namespace VeganBigBrother.Core.Entities
{
    public class SensorPart : BaseEntity
    {
        [MaxLength(50)]
        [Required(ErrorMessage = "Sensor part requires a name!")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Sensor part requires a type!")]
        public SensorPartType Type { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public virtual ICollection<SensorPartReading> SensorPartReadings { get; set; }

        public virtual ICollection<SensorSensorPart> SensorSensorParts { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}

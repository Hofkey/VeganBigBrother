using System.ComponentModel.DataAnnotations;
using VeganBigBrother.Core.Enums;

namespace VeganBigBrother.Core.Entities
{
    public class Sensor : BaseEntity
    {
        [MaxLength(50)]
        [Required(ErrorMessage = "Sensor name required!")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Sensor type required!")]
        public SensorType Type { get; set; }

        [Required(ErrorMessage = "Sensor location required!")]
        public int LocationID { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public virtual Location Location { get; set; }

        public virtual ICollection<SensorPart> SensorParts { get; set; }

        public virtual ICollection<SensorPartReading> SensorPartsReadings { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}

using System.ComponentModel.DataAnnotations;

namespace VeganBigBrother.Core.Entities
{
    public class SensorSensorPart : BaseEntity
    {
        [Required(ErrorMessage = "Sensor ID is required!")]
        public int SensorId { get; set; }

        [Required(ErrorMessage = "SensorPart ID is required!")]
        public int SensorPartId { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public virtual Sensor Sensor { get; set; }

        public virtual SensorPart SensorPart { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}

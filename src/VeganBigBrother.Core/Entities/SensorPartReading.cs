using System.ComponentModel.DataAnnotations;

namespace VeganBigBrother.Core.Entities
{
    public class SensorPartReading : BaseEntity
    {
        [Required(ErrorMessage = "A value is required!")]
        public double Value { get; set; }

        [Required(ErrorMessage = "A sensor part ID has to be provided!")]
        public int SensorPartID { get; set; }

        [Required(ErrorMessage = "A sensor ID has to be provided!")]
        public int SensorID { get; set; }

        [Required(ErrorMessage = "A reading date is required!")]
        public DateTime Time { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public virtual Sensor Sensor { get; set; }

        public virtual SensorPart SensorPart { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}

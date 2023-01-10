using System.ComponentModel.DataAnnotations;

namespace VeganBigBrother.Core.Entities
{
    public class Location : BaseEntity
    {
        [Required(ErrorMessage = "Location name is required!")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Location latitude is required!")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "Location longitude is required!")]
        public double Longitude { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public virtual ICollection<Sensor> Sensors { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}

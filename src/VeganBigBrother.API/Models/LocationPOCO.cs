using System.ComponentModel.DataAnnotations;

namespace VeganBigBrother.API.Models
{
    public class LocationPOCO
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Location requires a name!")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Location latitude is required!")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "Location longitude is required!")]
        public double Longitude { get; set; }
    }
}

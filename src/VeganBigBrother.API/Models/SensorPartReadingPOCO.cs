using System.ComponentModel.DataAnnotations;

namespace VeganBigBrother.API.Models
{
    public class SensorPartReadingPOCO
    {
        [Required(ErrorMessage = "A value is required!")]
        public double Value { get; set; }

        [Required(ErrorMessage = "A sensor part ID has to be provided!")]
        public int SensorPartID { get; set; }

        [Required(ErrorMessage = "A sensor ID has to be provided!")]
        public int SensorID { get; set; }

        [Required(ErrorMessage = "A reading date is required!")]
        public DateTime Time { get; set; }
    }
}
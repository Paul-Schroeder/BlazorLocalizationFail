using System;
using System.ComponentModel.DataAnnotations;
using static SprayCalc.Client.Consts.ComponentEnums;

namespace SprayCalc.Client.Models
{
    public class BaseMetricModel
    {
        [Range(1, 1000, ErrorMessage = "Invalid Value (must be between 1-1000).")]
        public decimal ChemicalCostPerLiter { get; set; }

        [Required]
        public DateTimeOffset CreatedOn { get; set; }

        [Range(1, 10, ErrorMessage = "Invalid Value (must be between 1-10).")]
        public decimal FlowRateLiterPerHour { get; set; }

        [Range(1, 100, ErrorMessage = "Invalid Value (must be between 1-100).")]
        public decimal GramsAiPerLiter { get; set; }

        [Required]
        public DateTimeOffset ModifiedOn { get; set; }

        [StringLength(5000, ErrorMessage = "Note is too long (5000 character limit).")]
        public string Note { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Product Name is too long (50 character limit).")]
        public string ProductName { get; set; }

        [Range(1, 50, ErrorMessage = "Invalid Value (must be between 1-50).")]
        public decimal SpeedKilometerPerHour { get; set; }

        [Required]
        [Range(typeof(SwathSize), nameof(SwathSize.Swath50Meter),
            nameof(SwathSize.Swath100Meter), ErrorMessage = "Pick a swath size.")]
        public SwathSize SwathSize { get; set; } = SwathSize.Swath50Meter;

        public Guid UserId { get; set; }
    }
}
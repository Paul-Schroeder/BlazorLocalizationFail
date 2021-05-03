using System;
using System.ComponentModel.DataAnnotations;

namespace SprayCalc.Client.Models
{
    public class MetricConcentrate : BaseMetricModel
    {
        [Range(1, 100, ErrorMessage = "Invalid Value (must be between 1-100).")]
        public decimal ChemicalParts { get; set; }

        [Range(1, 1000, ErrorMessage = "Invalid Value (must be between 1-1000).")]
        public decimal DiluentCostPerLiter { get; set; }

        [Range(1, 100, ErrorMessage = "Invalid Value (must be between 1-100).")]
        public decimal DiluentParts { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Wellness.Models;

namespace Wellness.ViewModels
{
    public class MetricViewModel
    {
        public int Id { get; set; }

        [Required]
        public DateTime Created { get; set; }
        [Required]
        public int ClothesWeight { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public double FatMass { get; set; }
        [Required]
        public double MuscleMass { get; set; }
        [Required]
        public double BodyMassIndex { get; set; }
        [Required]
        public int BasalMetabolicRate { get; set; }
        [Required]
        public double FatFreeMass { get; set; }
    }
}
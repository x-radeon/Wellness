using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Wellness.Models;

namespace Wellness.ViewModels
{
    public class SelfViewModel
    {
        [Required]
        public string PersonName { get; set; }
        [Required]
        public string BodyType { get; set; }
        [Required]
        public string GenderType { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public double Height { get; set; }
        [Required]
        public double IdealBodyWeight { get; set; }
        [Required]
        public double BoneMass { get; set; }
        public ICollection<WellnessUserMetric> Metrics { get; set; }
        public ICollection<WellnessUserWorkout> Workouts { get; set; }
    }
}
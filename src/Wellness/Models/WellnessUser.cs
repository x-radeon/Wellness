using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Wellness.Models
{
    public class WellnessUser : IdentityUser
    {
        public string PersonName { get; set; }
        public string BodyType { get; set; }
        public string GenderType { get; set; }
        public DateTime Birthdate { get; set; }
        public double Height { get; set; }
        public double IdealBodyWeight { get; set; }
        public double BoneMass { get; set; }
        public ICollection<WellnessUserMetric> Metrics { get; set; }
        public ICollection<WellnessUserWorkout> Workouts { get; set; }
    }
}
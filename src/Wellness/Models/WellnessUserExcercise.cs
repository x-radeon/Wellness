using System;
using System.Collections.Generic;

namespace Wellness.Models
{
    public class WellnessUserExcercise
    {
        public int Id { get; set; }
        public int ExcerciseId { get; set; }
        public DayOfWeek Day { get; set; }
        public int Slot { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public ICollection<WellnessUserExcerciseMetric> ExcerciseMetrics { get; set; }
    }
}
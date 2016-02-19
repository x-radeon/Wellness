using System;
using System.Collections.Generic;

namespace Wellness.Models
{
    public class WellnessUserWorkout
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string WorkoutName { get; set; }
        public int Weeks { get; set; }
        public ICollection<WellnessUserExcercise> Excercises { get; set; }
    }
}
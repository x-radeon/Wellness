namespace Wellness.Models
{
    public class WellnessUserExcerciseMetric
    {
        public int Id { get; set; }
        public int Week { get; set; }
        public int Slot { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        //This may need to be modified to support strings, new class?
        public int Result { get; set; }
    }
}
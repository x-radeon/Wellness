using System;

namespace Wellness.Models
{
    public class WellnessUserMetric
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime Created { get; set; }
        public int ClothesWeight { get; set; }
        public double Weight { get; set; }
        public double FatMass { get; set; }
        public double MuscleMass { get; set; }
        public double BodyMassIndex { get; set; }
        public int BasalMetabolicRate { get; set; }
        public double FatFreeMass { get; set; }
    }
}
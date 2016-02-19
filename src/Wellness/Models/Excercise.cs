using System;

namespace Wellness.Models
{
    public class Excercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public ExcerciseType ExcerciseType { get; set; }
    }
}
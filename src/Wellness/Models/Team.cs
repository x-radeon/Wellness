using System;
using System.Collections.Generic;

namespace Wellness.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public ICollection<WellnessUser> TeamMembers { get; set; }
    }
}
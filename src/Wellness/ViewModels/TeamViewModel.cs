using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Wellness.Models;

namespace Wellness.ViewModels
{
    public class TeamViewModel
    {
        [Required]
        public string Name { get; set; }

        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        public ICollection<WellnessUser> TeamMembers { get; set; }
    }
}

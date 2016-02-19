using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Wellness.Models;

namespace Wellness.ViewModels
{
    public class RegisterViewModel
    {
        //TODO: Add validations

        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string BodyType { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public double Height { get; set; }
        [Required]
        public double IdealBodyWeight { get; set; }
        [Required]
        public double BoneMass { get; set; }
    }
}
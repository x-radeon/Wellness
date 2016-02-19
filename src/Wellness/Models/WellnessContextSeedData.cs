using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Wellness.Models
{
    public class WellnessContextSeedData
    {
        private WellnessContext _context;
        private UserManager<WellnessUser> _userManager;

        public WellnessContextSeedData(WellnessContext context, UserManager<WellnessUser> userManger)
        {
            _context = context;
            _userManager = userManger;
        }

        public async Task EnsureSeedDataAsync()
        {
            if(await _userManager.FindByEmailAsync("harsh.austin@outlook.com") == null)
            {
                //add test user
                var user = new WellnessUser()
                {
                    UserName = "harsh.austin@outlook.com",
                    Email = "harsh.austin@outlook.com",
                    PersonName = "Austin Harsh",
                    BodyType = "Standard",
                    GenderType = "Male",
                    Birthdate = DateTime.Parse("Oct 24 1990"),
                    Height = 5.10,
                    IdealBodyWeight = 153.4,
                    BoneMass = 7.4
                };

                await _userManager.CreateAsync(user, "P@ssw0rd!");
            }

            if(!_context.UserMetrics.Any())
            {
                var someTestMetrics = new List<WellnessUserMetric>()
                {
                    new WellnessUserMetric() { Created = DateTime.Parse("Jan 14 2016 21:17"), ClothesWeight = 2, Weight = 204.4, FatMass = 53.6, MuscleMass = 143.4, BodyMassIndex = 29.3, BasalMetabolicRate = 2057, FatFreeMass = 150.8 },
                    new WellnessUserMetric() { Created = DateTime.Parse("Jan 21 2016 22:05"), ClothesWeight = 2, Weight = 202.2, FatMass = 51.8, MuscleMass = 143.0, BodyMassIndex = 29.0, BasalMetabolicRate = 2048, FatFreeMass = 150.4 },
                    new WellnessUserMetric() { Created = DateTime.Parse("Feb 06 2016 01:29"), ClothesWeight = 2, Weight = 198.0, FatMass = 45.6, MuscleMass = 144.8, BodyMassIndex = 28.4, BasalMetabolicRate = 2065, FatFreeMass = 152.4 },
                    new WellnessUserMetric() { Created = DateTime.Parse("Jul 17 2015 09:44"), ClothesWeight = 0, Weight = 206.4, FatMass = 49.2, MuscleMass = 149.4, BodyMassIndex = 29.6, BasalMetabolicRate = 2140, FatFreeMass = 157.2 },
                    new WellnessUserMetric() { Created = DateTime.Parse("Jun 20 2015 09:48"), ClothesWeight = 0, Weight = 207.2, FatMass = 47.8, MuscleMass = 151.6, BodyMassIndex = 29.7, BasalMetabolicRate = 2168, FatFreeMass = 151.6 },
                    new WellnessUserMetric() { Created = DateTime.Parse("Jun 27 2015 09:17"), ClothesWeight = 0, Weight = 205.6, FatMass = 50.4, MuscleMass = 147.6, BodyMassIndex = 29.5, BasalMetabolicRate = 2115, FatFreeMass = 155.2 }
                };

                _context.AddRange(someTestMetrics);
            }

            _context.SaveChanges();
        }
    }
}
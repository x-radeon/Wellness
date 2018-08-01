using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Wellness.Models
{
    public class WellnessContext : IdentityDbContext<WellnessUser>
    {
        public WellnessContext(DbContextOptions<WellnessContext> options)
            : base(options)
        {
        }

        public DbSet<Excercise> Excercises { get; set; }
        public DbSet<ExcerciseType> ExcerciseType { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<WellnessUser> WellnessUsers { get; set; }
        public DbSet<WellnessUserExcercise> UserExcercises { get; set; }
        public DbSet<WellnessUserExcerciseMetric> UserExcercieMetrics { get; set; }
        public DbSet<WellnessUserMetric> UserMetrics { get; set; }
        public DbSet<WellnessUserWorkout> UserWorkouts { get; set; }
    }
}
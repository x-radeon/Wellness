using System;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace Wellness.Models
{
    public class WellnessContext : IdentityDbContext<WellnessUser>
    {
        public WellnessContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Excercise> Excercises { get; set; }
        public DbSet<ExcerciseType> ExcerciseType { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<WellnessUser> WellnessUsers { get; set; }
        public DbSet<WellnessUserExcercise> UserExcercises { get; set; }
        public DbSet<WellnessUserExcerciseMetric> UserExcercieMetrics { get; set; }
        public DbSet<WellnessUserMetric> UserMetrics { get; set; }
        public DbSet<WellnessUserWorkout> UserWorkouts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Startup.Configuration["Data:ConnectionString"];

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
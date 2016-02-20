using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wellness.Models
{
    public class WellnessRepository : IWellnessRepository
    {
        private WellnessContext _context;
        private ILogger<WellnessRepository> _logger;

        public WellnessRepository(WellnessContext context, ILogger<WellnessRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddUserMetric(WellnessUserMetric metric)
        {
            _context.Add(metric);
        }

        public void AddWorkout(WellnessUserWorkout workout)
        {
            _context.Add(workout);
        }

        public void CreateTeam(Team team)
        {
            _context.Add(team);
        }

        public void DeleteUserMetric(WellnessUserMetric metric)
        {
            _context.Remove(metric);
        }

        public void DeleteWorkout(WellnessUserWorkout workout)
        {
            _context.Remove(workout);
        }

        public IEnumerable<WellnessUser> GetAllUsers()
        {
            return _context.WellnessUsers
                .OrderBy(t => t.PersonName)
                .ToList();
        }

        public IEnumerable<WellnessUser> GetTeamMembers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WellnessUser> GetTeamMembers(string teamName)
        {
            throw new NotImplementedException();
            //return _context.Teams
            //    .Where(t => t.Name == teamName);
        }

        public IEnumerable<WellnessUser> GetTeamMembersMetrics()
        {
            throw new NotImplementedException();
        }

        public WellnessUser GetUser(string name)
        {
            return _context.WellnessUsers
                .Where(t => t.UserName == name)
                .FirstOrDefault();
        }

        public WellnessUserMetric GetUserMetric(int id, string name)
        {
            return _context.UserMetrics
                .Where(t => t.UserName == name && t.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<WellnessUserMetric> GetUserMetrics(string name)
        {
            return _context.UserMetrics
                .Where(t => t.UserName == name)
                .OrderByDescending(t => t.Created)
                .ToList();
        }

        public void JoinTeam(Team team, string name)
        {
            throw new NotImplementedException();
            //_context.Teams.Update(t => team.Name == t.name)
        }

        public void LeaveTeam(Team team)
        {
            throw new NotImplementedException();
        }

        public void ModifyUserMetric(WellnessUserMetric metric)
        {
            _context.Update(metric);
        }

        public void ModifyWorkout(WellnessUserWorkout workout)
        {
            _context.Update(workout);
        }

        public bool SaveAll()
        {
             return _context.SaveChanges() > 0;
        }

        public void UpdateTeam(Team team)
        {
            _context.Update(team);
        }

        public void UpdateUser(WellnessUser user)
        {
            _context.Update(user);
        }

        public IEnumerable<WellnessUserWorkout> Workouts(string name)
        {
            try
            {
                return _context.UserWorkouts
                    .OrderBy(t => t.WorkoutName)
                    .Where(t => t.UserName == name)
                    .ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError("Could not get Workouts from db", ex);
                return null;
            }
        }
    }
}
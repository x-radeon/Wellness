using System;
using System.Collections.Generic;

namespace Wellness.Models
{
    public interface IWellnessRepository
    {
        //Global
        IEnumerable<WellnessUser> GetAllUsers();
        bool SaveAll();

        //Team
        IEnumerable<WellnessUser> GetTeamMembers(string name);
        IEnumerable<WellnessUser> GetTeamMembersMetrics();
        void CreateTeam(Team team);
        void UpdateTeam(Team team);
        void JoinTeam(Team team, string name);
        void LeaveTeam(Team team);

        //Self
        WellnessUser GetUser(string name);
        void UpdateUser(WellnessUser user);
        IEnumerable<WellnessUserMetric> GetUserMetrics(string name);
        WellnessUserMetric GetUserMetric(int id, string name);
        void AddUserMetric(WellnessUserMetric metric);
        void ModifyUserMetric(WellnessUserMetric metric);
        void DeleteUserMetric(WellnessUserMetric metric);

        //Workouts
        IEnumerable<WellnessUserWorkout> Workouts(string name);
        void AddWorkout(WellnessUserWorkout workout);
        void ModifyWorkout(WellnessUserWorkout workout);
        void DeleteWorkout(WellnessUserWorkout workout);

        //Excercise
        //TODO
    }
}
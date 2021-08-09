using System;
using System.Collections.Generic;
using System.Linq;
using TeamService.Models;

namespace TeamService.Persistence {
    public class MemoryTeamRepository : ITeamRepository {
        protected static ICollection<Team> teams;

        public MemoryTeamRepository()
        {
            teams ??= new List<Team>();
        }

        public MemoryTeamRepository(ICollection<Team> teams)
        {
            MemoryTeamRepository.teams = teams;
        }

        public IEnumerable<Team> GetTeams()
        {
            return teams;
        }

        public void AddTeam(Team team)
        {
            teams.Add(team);
        }

        public Team Get(Guid id)
        {
            return teams.FirstOrDefault(t => t.ID == id);
        }
    }
}
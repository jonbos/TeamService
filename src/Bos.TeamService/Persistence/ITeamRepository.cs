using System;
using System.Collections.Generic;
using TeamService.Models;

namespace TeamService.Persistence {
    public interface ITeamRepository {
        IEnumerable<Team> GetTeams();
        void AddTeam(Team team);
        Team Get(Guid id);
    }
}
using System.Collections.Generic;
using TeamService.Models;
using TeamService.Persistence;

namespace Bos.TeamService.Tests {
    public class TestMemoryRepository {
        public class TestMemoryTeamRepository : MemoryTeamRepository {
            public TestMemoryTeamRepository() : base(CreateInitialFake())
            {
            }

            private static ICollection<Team> CreateInitialFake()
            {
                var teams = new List<Team>();
                teams.Add(new Team("one"));
                teams.Add(new Team("two"));

                return teams;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TeamService.Controllers;
using TeamService.Models;
using Xunit;

namespace Bos.TeamService.Tests {
    public class UnitTest1 {
        [Fact]
        public void QueryTeamListReturnsCorrectTeams()
        {
            TeamsController controller = new TeamsController(new TestMemoryRepository.TestMemoryTeamRepository());
            var rawTeams = (IEnumerable<Team>) (controller.GetAllTeams() as ObjectResult)?.Value;
            List<Team> teams = new List<Team>(rawTeams);
            Assert.Equal(2, teams.Count);
            Assert.Equal("one", teams[0].Name);
            Assert.Equal("two", teams[1].Name);
        }

        [Fact]
        public async void CreateTeamsAddsTeamToList()
        {
            TeamsController controller = new TeamsController(new TestMemoryRepository.TestMemoryTeamRepository());
            var teams = (IEnumerable<Team>) (controller.GetAllTeams() as ObjectResult).Value;
            List<Team> original = new List<Team>(teams);

            Team t = new Team("sample");
            var result = controller.CreateTeam(t);
            Assert.Equal(201, (result as ObjectResult).StatusCode);

            var actionResult = controller.GetAllTeams() as ObjectResult;
            var newTeamsRaw = (IEnumerable<Team>) (controller.GetAllTeams() as ObjectResult)?.Value;
            List<Team> newTeams = new List<Team>(newTeamsRaw);
            Assert.Equal(newTeams.Count, original.Count+1);
            var sampleTeam = newTeams.FirstOrDefault( target => target.Name == "sample");
            Assert.NotNull(sampleTeam);            
        }
    }
}
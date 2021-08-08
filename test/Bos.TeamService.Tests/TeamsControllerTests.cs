using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TeamService.Controllers;
using TeamService.Models;
using Xunit;

namespace Bos.TeamService.Tests {
    public class UnitTest1 {
        [Fact]
        public void QueryTeamListReturnsCorrectTeams()
        {
            TeamsController controller = new TeamsController();
            List<Team> teams = new List<Team>(controller.GetAllTeams());
        }
    }
}
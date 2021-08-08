using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TeamService.Models;

namespace TeamService.Controllers {
    public class TeamsController {
        public TeamsController()
        {
        }

        [HttpGet]
        public IEnumerable<Team> GetAllTeams()
        {
            return new Team[] {new Team("one"), new Team("two")};
        }
    }
}
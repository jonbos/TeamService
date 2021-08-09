using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamService.Models;
using TeamService.Persistence;

namespace TeamService.Controllers {
    [Route("[controller]")]
    public class TeamsController : Controller {
        ITeamRepository repository;

        public TeamsController(ITeamRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public virtual IActionResult GetAllTeams()
        {
            return this.Ok(repository.GetTeams());
        }

        [HttpPost]
        public virtual IActionResult CreateTeam([FromBody] Team team)
        {
            repository.Add(team);
            return this.Created($"/teams/{team.ID}", team);
        }

        [HttpGet("{id}")]
        public IActionResult GetTeam(Guid id)
        {
            Team team = repository.Get(id);

            if (team != null) // I HATE NULLS, MUST FIXERATE THIS.			  
            {
                return this.Ok(team);
            }
            else
            {
                return this.NotFound();
            }
        }

        [HttpPut("{id}")]
        public virtual IActionResult UpdateTeam(Team team, Guid id)
        {
            team.ID = id;

            if (repository.Update(team) == null)
            {
                return this.NotFound();
            }
            else
            {
                return this.Ok(team);
            }
        }

        [HttpDelete("{id}")]
        public virtual IActionResult DeleteTeam(Guid id)
        {
            Team team = repository.Delete(id);

            return team != null ? this.Ok(team) : this.NotFound();
        }
    }
}
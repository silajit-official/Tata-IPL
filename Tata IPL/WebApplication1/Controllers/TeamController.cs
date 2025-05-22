using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repository;
using System.Linq;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        IConfiguration _configuration;
        MyIPLContext _context;
        IPLRepository repository;
        public TeamController(IConfiguration configuration,MyIPLContext context)
        {
            _configuration = configuration;
            _context = context;
            repository = new IPLRepository(_context);
        }
        [HttpGet("Test1")]
        public IActionResult Mygetdata()
        {
            
            return Ok(_configuration.GetValue<string>("Azure-Key:key1"));
        }

        [HttpGet("Test2/{id?}")]
        public IActionResult Mygetdata1(IConfiguration configuration)
        {
            return Ok("Hello123- "+configuration.GetConnectionString("MainConnection"));
        }

        [HttpGet("GetTeams")]
        public IActionResult GetAllTeam()
        {
            List<Table_Classes.Team> teams = repository.GetAllTeam();

            return Ok(teams);

        }
        [HttpGet("GetTeamByID")]
        public IActionResult GetTeamByID(int tid)
        {
            return Ok(repository.GetTeamByID(tid));
        }

        [HttpPost("AddTeam")]
        public IActionResult AddTeam([FromBody] Team team)
        {
            Team t = team;
            t.Win=t.Win ?? 0;
            t.Lose = t.Lose ?? 0;
            t.Draw = t.Draw ?? 0;
            _context.Teams.Add(t);
            _context.SaveChanges();
            return Ok();
        }
    }
}

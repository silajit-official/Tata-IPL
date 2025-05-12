using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : Controller
    {
        MyIPLContext _context;
        IPLRepository repository;
        public PlayerController(MyIPLContext context)
        {
            _context = context;
            repository = new IPLRepository(_context);
        }
        [HttpPost("AddPlayer")]
        public IActionResult AddPlayer([FromBody] Table_Classes.Player player)
        {
            Player p = new Player()
            {
                Name = player.Name,
                PTid = player.PTid
            };
            _context.Players.Add(p);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("GetPlayer/{tid}")]
        public IActionResult GetTeamPlayer(int tid)
        {
            List<Player> players = repository.GetPlayerByTeamID(tid);
            return Ok(players);
        }

        [HttpGet("GetPlayer")]
        public IActionResult GetAllPlayer()
        {
            List<Player> players = (from p in _context.Players
                                    select p).ToList();
            return Ok(players);
        }
    }
}

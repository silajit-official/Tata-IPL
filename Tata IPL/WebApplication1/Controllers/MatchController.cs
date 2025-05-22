using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchController : Controller
    {
        MyIPLContext _context;
        IPLRepository repository;
        public MatchController(MyIPLContext context)
        {
            _context = context;
            repository = new IPLRepository(_context);
        }
        [HttpPost("GenerateMatches")]
        public IActionResult GenerateMatches()
        {
            List<Table_Classes.Team> teams = repository.GetAllTeam();
            List<int> teamids = new List<int>();
            List<TeamMatch> teamMatches = new List<TeamMatch>();
            foreach (var item in teams)
            {
                teamids.Add(item.Tid??0);
            }

            DateTime d = DateTime.Now;
            DateTime dateTime=DateTime.Now;
            for (int i=0;i<teamids.Count;i++)
            {
                int team1, team2;
                for(int j=0;j<teamids.Count;j++)
                {
                    if (i == j)
                        continue;
                    team1 = teamids[i];
                    team2 = teamids[j];
                    if(i==0 && j==0)
                    {
                        dateTime = d;
                    }
                    else
                        dateTime = dateTime.AddDays(1);
                    TeamMatch teamMatch = new TeamMatch()
                    {
                        Team1 = team1,
                        Team2 = team2,
                        PlayedOn = dateTime
                    };
                    teamMatches.Add(teamMatch);
                    
                }
            }
            Random rng = new Random();
            teamMatches = teamMatches.OrderBy(x => rng.Next()).ToList();
            _context.TeamMatches.AddRange(teamMatches);
            _context.SaveChanges();
            List<TeamMatch> DBTeamMatches = new List<TeamMatch>();
            List<MatchDetail> matchDetails = new List<MatchDetail>();

            DBTeamMatches = (from match in _context.TeamMatches select match).ToList();
            foreach (var item in DBTeamMatches)
            {
                matchDetails.Add(new MatchDetail()
                {
                    MdTmId = item.Tmid
                });
            }
            _context.MatchDetails.AddRange(matchDetails);
            _context.SaveChanges();
            return Ok();
        }


        [HttpPost("AddMatchDetails")]
        public IActionResult AddMatchDetails([FromBody] MatchDetail matchDetail)
        {
            MatchDetail detail = (from md in _context.MatchDetails where md.MdTmId == matchDetail.MdTmId select md).FirstOrDefault();
            if (detail == null)
                return BadRequest();
            else
            {
                detail.PlayerOfTheMatch = matchDetail.PlayerOfTheMatch;
                detail.WinByRuns = matchDetail.WinByRuns;
                detail.WinByWickets = matchDetail.WinByWickets;
                detail.FirstTeamBat = matchDetail.FirstTeamBat;
                detail.PlayerOfTheMatch = matchDetail.PlayerOfTheMatch;
                _context.SaveChanges();


                int winnerTeam=0, loosingTeam=0;
                TeamMatch teamPlayed = (from tm in _context.TeamMatches where tm.Tmid == matchDetail.MdTmId select tm).FirstOrDefault();
                if (matchDetail.WinByRuns!=null)
                {
                    winnerTeam = (int)matchDetail.FirstTeamBat;
                    loosingTeam = ((teamPlayed.Team1 == winnerTeam) ? teamPlayed.Team2 : teamPlayed.Team1);

                }
                else
                {
                    winnerTeam= ((teamPlayed.Team1 == (int)matchDetail.FirstTeamBat) ? teamPlayed.Team2 : teamPlayed.Team1);
                    loosingTeam = (int)matchDetail.FirstTeamBat;
                }

                Team team = (from t in _context.Teams where t.Tid == winnerTeam select t).FirstOrDefault();
                int points = team.Points, win = team.Win??0;
                team.Points = points + 2;
                team.Win = win + 1;
                _context.SaveChanges();

                team = (from t in _context.Teams where t.Tid == loosingTeam select t).FirstOrDefault();
                team.Lose =  + 1;
                _context.SaveChanges();

                return Ok();
            }
        }

        [HttpGet("GetAllMatches")]
        public IActionResult GetAllMatches()
        {
            var match = (from tm in _context.TeamMatches join t1 in _context.Teams on tm.Team1 equals t1.Tid
                         join t2 in _context.Teams on tm.Team2 equals t2.Tid
                         select new
                         {
                             tid=tm.Tmid,
                             team1=tm.Team1,
                             team1Name=t1.TeamName,
                             team2=tm.Team2,
                             team2Name=t2.TeamName,
                             playedon=tm.PlayedOn
                         }).ToList();

            List<Table_Classes.CustomTeamMatch> teamMatches = new List<Table_Classes.CustomTeamMatch>();

            foreach (var item in match)
            {
                Table_Classes.CustomTeamMatch tm = new Table_Classes.CustomTeamMatch();
                tm.Tmid = item.tid;
                tm.Team1 = item.team1;
                tm.Team1_Name = item.team1Name;
                tm.Team2 = item.team2;
                tm.Team2_Name = item.team2Name;
                tm.PlayedOn = item.playedon;

                teamMatches.Add(tm);

            }

            return Ok(teamMatches);
        }

    }


    
}

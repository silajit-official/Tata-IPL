using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class IPLRepository
    {
        MyIPLContext _context;
        public IPLRepository( MyIPLContext context)
        {
            _context = context;
        }
        public List<Table_Classes.Team> GetAllTeam()
        {
            List<Table_Classes.Team> teams = (from t in _context.Teams
                                              select new Table_Classes.Team
                                              {
                                                  Tid=t.Tid,
                                                  TeamName = t.TeamName,
                                                  Points = t.Points,
                                                  Win = t.Win,
                                                  Lose = t.Lose,
                                                  Draw = t.Draw
                                              }
                      ).ToList();

            return (teams);

        }

        public List<Player> GetPlayerByTeamID(int tid)
        {
            List<Player> players = (from p in _context.Players
                                    where p.PTid == tid
                                    select p).ToList();
            return (players);
        }
        public Table_Classes.Team GetTeamByID(int tid)
        {
            Table_Classes.Team teams = (from t in _context.Teams
                                        where t.Tid == tid
                                        select new Table_Classes.Team
                                        {
                                            Tid = t.Tid,
                                            TeamName = t.TeamName,
                                            Points = t.Points,
                                            Win = t.Win,
                                            Lose = t.Lose,
                                            Draw = t.Draw
                                        }
                      ).FirstOrDefault();

            return (teams);

        }
    }

    
    }

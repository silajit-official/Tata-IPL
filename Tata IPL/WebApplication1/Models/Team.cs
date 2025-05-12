using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Team
{
    public int Tid { get; set; }

    public string TeamName { get; set; } = null!;

    public int Points { get; set; }

    public int? Win { get; set; }

    public int? Lose { get; set; }

    public int? Draw { get; set; }

    public virtual ICollection<MatchDetail> MatchDetails { get; set; } = new List<MatchDetail>();

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();

    public virtual ICollection<TeamMatch> TeamMatchTeam1Navigations { get; set; } = new List<TeamMatch>();

    public virtual ICollection<TeamMatch> TeamMatchTeam2Navigations { get; set; } = new List<TeamMatch>();
}

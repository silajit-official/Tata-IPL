using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class TeamMatch
{
    public int Tmid { get; set; }

    public int Team1 { get; set; }

    public int Team2 { get; set; }

    public DateTime PlayedOn { get; set; }

    public virtual ICollection<MatchDetail> MatchDetails { get; set; } = new List<MatchDetail>();

    public virtual Team Team1Navigation { get; set; } = null!;

    public virtual Team Team2Navigation { get; set; } = null!;
}

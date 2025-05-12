using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class MatchDetail
{
    public int? MdId { get; set; }

    public string? PlayerOfTheMatch { get; set; } = null!;

    public int? MdTmId { get; set; }

    public int? WinByRuns { get; set; }

    public int? WinByWickets { get; set; }

    public int? FirstTeamBat { get; set; }

    public virtual Team? FirstTeamBatNavigation { get; set; }

    public virtual TeamMatch? MdTm { get; set; }
}

using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Player
{
    public int Pid { get; set; }

    public string Name { get; set; } = null!;

    public int? PTid { get; set; }

    public virtual Team? PT { get; set; }
}

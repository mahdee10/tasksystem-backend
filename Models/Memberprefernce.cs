using System;
using System.Collections.Generic;

namespace TaskSystemServer.Models;

public partial class Memberprefernce
{
    public int MemberId { get; set; }

    public string? Layout { get; set; }

    public string? Theme { get; set; }

    public virtual Member Member { get; set; } = null!;
}

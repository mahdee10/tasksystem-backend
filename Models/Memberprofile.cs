using System;
using System.Collections.Generic;

namespace TaskSystemServer.Models;

public partial class Memberprofile
{
    public int MemberId { get; set; }

    public string? ProfileUrl { get; set; }

    public virtual Member Member { get; set; } = null!;
}

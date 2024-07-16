using System;
using System.Collections.Generic;

namespace TaskSystemServer.Models;

public partial class Registeredglobalevent
{
    public int MemberId { get; set; }

    public int EventId { get; set; }

    public int? RemindBeforeHours { get; set; }

    public virtual Globalevent Event { get; set; } = null!;

    public bool? IsReminded { get; set; }
    public virtual Member Member { get; set; } = null!;
}

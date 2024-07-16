using System;
using System.Collections.Generic;

namespace TaskSystemServer.Models;

public partial class Event
{
    public int EventId { get; set; }

    public int MemberId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? Date { get; set; }

    public int? RemindBeforeHours { get; set; }

    public bool? IsReminded { get; set; }

    public virtual Member Member { get; set; } = null!;
}

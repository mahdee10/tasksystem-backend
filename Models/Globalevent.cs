using System;
using System.Collections.Generic;
using TaskSystemServer.Dtos.GlobalEvents;

namespace TaskSystemServer.Models;

public partial class Globalevent
{
    public int EventId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? Date { get; set; }

    public virtual ICollection<Registeredglobalevent> Registeredglobalevents { get; set; } = new List<Registeredglobalevent>();

    public static implicit operator Globalevent(GlobalEventDto v)
    {
        throw new NotImplementedException();
    }
}

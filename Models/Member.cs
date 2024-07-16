using System;
using System.Collections.Generic;

namespace TaskSystemServer.Models;

public partial class Member
{
    public int MemberId { get; set; }

    public string? Name { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Timezone { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual Memberprefernce? Memberprefernce { get; set; }

    public virtual Memberprofile? Memberprofile { get; set; }

    public virtual ICollection<Registeredglobalevent> Registeredglobalevents { get; set; } = new List<Registeredglobalevent>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public string? AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
}

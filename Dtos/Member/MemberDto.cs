using TaskSystemServer.Dtos.Event;
using TaskSystemServer.Dtos.Preferences;
using TaskSystemServer.Dtos.Registeredglobalevent;
using TaskSystemServer.Dtos.Task;
using TaskSystemServer.Mappers;
using TaskSystemServer.Models;

namespace TaskSystemServer.Dtos.Member
{
    public class MemberDto
    {
        public int MemberId { get; set; }

        public string? Name { get; set; }

        public DateOnly? Dob { get; set; }

        public string? Timezone { get; set; }

        public bool? IsActive { get; set; }

        public virtual IEnumerable<EventDto> Events { get; set; } = new List<EventDto?>();

        public virtual PreferenceDto? Memberprefernce { get; set; }

        //public virtual Memberprofile? Memberprofile { get; set; }

        public virtual IEnumerable<RegisteredglobaleventDto> Registeredglobalevents { get; set; } = new List<RegisteredglobaleventDto>();

        public virtual IEnumerable<TaskDto> Tasks { get; set; } = new List<TaskDto>();

        //public string? AppUserId { get; set; }
        //public AppUser? AppUser { get; set; }

        public MemberDto(int memberId, string name, DateOnly? dob,string timezone,bool? isActive, Memberprefernce prefrence, IEnumerable<EventDto> events, IEnumerable<TaskDto> tasks, IEnumerable<RegisteredglobaleventDto> registeredglobalevents)
        {
            MemberId = memberId;
            Name = name;
            Dob = dob;
            Timezone = timezone;
            IsActive = isActive;
            Memberprefernce = prefrence.ToPreferenceDto();
            Events = events;
            Tasks = tasks;
            Registeredglobalevents = registeredglobalevents;
        }
    }
}

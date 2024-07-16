using TaskSystemServer.Dtos.GlobalEvents;
using TaskSystemServer.Mappers;
using TaskSystemServer.Models;

namespace TaskSystemServer.Dtos.Registeredglobalevent
{
    public class RegisteredglobaleventDto
    {
        //public int MemberId { get; set; }

        //public int EventId { get; set; }

        public int? RemindBeforeHours { get; set; }

        public virtual GlobalEventDto Event { get; set; } = null!;

        //public virtual Member Member { get; set; } = null!;

        public RegisteredglobaleventDto(int? remindBefore, Globalevent ev) {
            RemindBeforeHours = remindBefore;
            Event = ev.ToGlobalEventDto();
        }
    }
}

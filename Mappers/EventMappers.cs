using TaskSystemServer.Dtos.Event;
using TaskSystemServer.Dtos.Member;
using TaskSystemServer.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskSystemServer.Mappers
{
    public static class EventMappers
    {
        public static EventDto ToEventDto(this Event member)
        {
            return new EventDto
            {
                EventId=member.EventId,
                Title=member.Title,
                Description=member.Description,
                Date=member.Date,
                
                RemindBeforeHours=member.RemindBeforeHours
            };

        }

        public static Event ToEventFromCreate(this CreateEventDto ev,int id)
        {

            return new Event
            {
                MemberId=id,
                Title = ev.Title,
                Description = ev.Description,
                Date = ev.Date,
                IsReminded=false,
                RemindBeforeHours = ev.RemindBeforeHours
            };

        }
    }
}

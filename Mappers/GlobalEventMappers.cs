using TaskSystemServer.Dtos.Event;
using TaskSystemServer.Dtos.GlobalEvents;
using TaskSystemServer.Models;

namespace TaskSystemServer.Mappers
{
    public static class GlobalEventMappers
    {
        public static GlobalEventDto ToGlobalEventDto(this Globalevent member)
        {
            return new GlobalEventDto
            {
                EventId = member.EventId,
                Title = member.Title,
                Description = member.Description,
                Date = member.Date,
            };

        }

        public static Globalevent ToGlobalEventFromCreate(this CreateGlobalEventDto ev)
        {

            return new Globalevent
            {
                Title = ev.Title,
                Description = ev.Description,
                Date = ev.Date,
            };

        }
    }
}

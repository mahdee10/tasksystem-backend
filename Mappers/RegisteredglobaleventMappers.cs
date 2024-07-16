using TaskSystemServer.Dtos.GlobalEvents;
using TaskSystemServer.Dtos.Registeredglobalevent;
using TaskSystemServer.Models;

namespace TaskSystemServer.Mappers
{
    public static class RegisteredglobaleventMappers
    {
        public static RegisteredglobaleventDto ToRegisteredGlobalEventDto(this Registeredglobalevent regEvent)
        {
            return new RegisteredglobaleventDto(regEvent.RemindBeforeHours, regEvent.Event);
            //{
            //    RemindBeforeHours = regEvent.RemindBeforeHours,
            //    Event= regEvent.Event
            //};

        }

        public static Registeredglobalevent ToRegisteredGlobalEventFromCreate(this CreateRegisteredglobaleventDto ev,int evId,int memberId)
        {

            return new Registeredglobalevent
            {
                EventId=evId,
                MemberId= memberId,
                RemindBeforeHours=ev.RemindBeforeHours,
                IsReminded=false
            };

        }
    }
}

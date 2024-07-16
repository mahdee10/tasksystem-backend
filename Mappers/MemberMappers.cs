using System;
using TaskSystemServer.Dtos.Account;
using TaskSystemServer.Dtos.Member;
using TaskSystemServer.Models;
namespace TaskSystemServer.Mappers
{
    public static class MemberMappers
    {
        public static MemberDto ToMemberDto(this Member member)
        {

            var eventsDto= member.Events.Select(e => e.ToEventDto());
            var tasksDto= member.Tasks.Select(e => e.ToTaskDto());
            var registeredGlobalEventsDto= member.Registeredglobalevents.Select(e => e.ToRegisteredGlobalEventDto());
            return new MemberDto(member.MemberId, member.Name, member.Dob, member.Timezone, member.IsActive, member.Memberprefernce, eventsDto, tasksDto, registeredGlobalEventsDto);

        }

        public static Member ToMemberFromCreateDto(this CreateMemberDto member) {
            return new Member{
                Name = member.Name,
                Dob = member.Dob,
                Timezone= member.Timezone,
                AppUserId = member.AppUserId
            };
        }

    }
}

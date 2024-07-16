using TaskSystemServer.Dtos.MemberProfile;
using TaskSystemServer.Models;

namespace TaskSystemServer.Mappers
{
    public static class MemberProfileMappers
    {
        public static Memberprofile ToMemberProfileFromCreate(this CreateMemberProfileDto memberprofile)
        {
            return new Memberprofile { 
                ProfileUrl = memberprofile.ProfileUrl
            };
        }
    }
}

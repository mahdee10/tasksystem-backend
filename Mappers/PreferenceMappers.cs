using TaskSystemServer.Dtos.Event;
using TaskSystemServer.Dtos.Preferences;
using TaskSystemServer.Models;

namespace TaskSystemServer.Mappers
{
    public static class PreferenceMappers
    {
        public static PreferenceDto ToPreferenceDto(this Memberprefernce pre)
        {
            return new PreferenceDto
            {
                Theme = pre.Theme,
                Layout = pre.Layout
            };

        }
    }
}

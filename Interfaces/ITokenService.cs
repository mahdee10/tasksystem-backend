using TaskSystemServer.Models;

namespace TaskSystemServer.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(AppUser user, int id);
    }
}

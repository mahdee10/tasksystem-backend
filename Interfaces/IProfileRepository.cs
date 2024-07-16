using TaskSystemServer.Models;

namespace TaskSystemServer.Interfaces
{
    public interface IProfileRepository
    {
        Task<Memberprofile?> GetByIdAsync(int id);
        Task<Memberprofile> DeleteAsync(int id);
        Task<Memberprofile> CreateAsync(Memberprofile profile);
    }
}

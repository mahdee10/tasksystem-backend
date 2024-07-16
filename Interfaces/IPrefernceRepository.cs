using System.Reflection.Metadata;
using TaskSystemServer.Dtos.Preferences;
using TaskSystemServer.Models;

namespace TaskSystemServer.Interfaces
{
    public interface IPrefernceRepository
    {
        Task<Memberprefernce?> GetByIdAsync(int id);
        Task<Memberprefernce> UpdateAsync(int id, PreferenceDto preference);
        Task<Memberprefernce> CreateAsync(Memberprefernce preference);
    }
}

using TaskSystemServer.Dtos.GlobalEvents;
using TaskSystemServer.Dtos.Registeredglobalevent;
using TaskSystemServer.Models;

namespace TaskSystemServer.Interfaces
{
    public interface IRegisteredglobaleventRepository
    {
        Task<List<Registeredglobalevent>> GetByIdAsync(int memberId);
        Task<Registeredglobalevent> GetByRegisteredglobaleventIdAsync(int evId, int memberId);
        Task<Registeredglobalevent?> UpdateAsync(int evId, int memberId, UpdateRegisteredglobaleventDto ev);
        Task<Registeredglobalevent> DeleteAsync(int evId, int memberId);
        Task<Registeredglobalevent> CreateAsync(Registeredglobalevent ev);
    }
}

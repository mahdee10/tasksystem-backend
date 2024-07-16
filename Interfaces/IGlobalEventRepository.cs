using TaskSystemServer.Dtos.Event;
using TaskSystemServer.Dtos.GlobalEvents;
using TaskSystemServer.Models;

namespace TaskSystemServer.Interfaces
{
    public interface IGlobalEventRepository
    {
        Task<List<Globalevent>> GetByIdAsync();
        Task<Globalevent> GetByEventIdAsync(int id);
        Task<Globalevent?> UpdateAsync(int id, CreateGlobalEventDto ev);
        Task<Globalevent> DeleteAsync(int id);
        Task<Globalevent> CreateAsync(Globalevent ev);
    }
}

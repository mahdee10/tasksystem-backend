using TaskSystemServer.Dtos.Event;
using TaskSystemServer.Models;

namespace TaskSystemServer.Interfaces
{
    public interface IEventRepository
    {
        Task<List<Event?>> GetByIdAsync(int id);
        Task<Event> GetByEventIdAsync(int id);
        Task<Event?> UpdateAsync(int id, UpdateEventDto ev);
        Task<Event> DeleteAsync(int id);
        Task<Event> CreateAsync(Event ev);

    }
}

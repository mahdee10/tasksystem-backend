using Microsoft.EntityFrameworkCore;
using TaskSystemServer.Data;
using TaskSystemServer.Dtos.Event;
using TaskSystemServer.Interfaces;
using TaskSystemServer.Models;

namespace TaskSystemServer.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly TasksystemContext _context;
        public EventRepository(TasksystemContext context) {
            _context = context;
        }

        public async Task<Event> CreateAsync(Event ev)
        {
            await _context.Events.AddAsync(ev);
            await _context.SaveChangesAsync();
            return ev;
        }

        public async Task<Event> DeleteAsync(int id)
        {
    
                var ev = _context.Events.FirstOrDefault(d => d.EventId == id);
                if (ev == null)
                {
                    return null;
                }
                _context.Events.Remove(ev);
                await _context.SaveChangesAsync();

                return ev;
            
        }

        public async Task<Event> GetByEventIdAsync(int id)
        {
            return await _context.Events.FindAsync(id);
        }

        public async Task<List<Event?>> GetByIdAsync(int id)
        {
            return await _context.Events.Where(e => e.MemberId == id).ToListAsync();
        }

        public async Task<Event?> UpdateAsync(int id, UpdateEventDto ev)
        {
            var eventModel = await _context.Events.FirstOrDefaultAsync(x => x.EventId == id);
            if (eventModel == null)
            {
                return null;
            }
            eventModel.Title = ev.Title;
            eventModel.Description = ev.Description;
            eventModel.Date = ev.Date;
            eventModel.RemindBeforeHours = ev.RemindBeforeHours;
            await _context.SaveChangesAsync();
            return eventModel;
        }


    }
}

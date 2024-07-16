using Microsoft.EntityFrameworkCore;
using TaskSystemServer.Data;
using TaskSystemServer.Dtos.GlobalEvents;
using TaskSystemServer.Interfaces;
using TaskSystemServer.Models;

namespace TaskSystemServer.Repository
{
    public class GlobalEventRepository : IGlobalEventRepository
    {
        private readonly TasksystemContext _context;
        public GlobalEventRepository(TasksystemContext context)
        {
            _context = context;
        }

        public async Task<Globalevent> CreateAsync(Globalevent ev)
        {
            await _context.Globalevents.AddAsync(ev);
            await _context.SaveChangesAsync();
            return ev;
        }

        public async Task<Globalevent> DeleteAsync(int id)
        {
            var ev = _context.Globalevents.FirstOrDefault(d => d.EventId == id);
            if (ev == null)
            {
                return null;
            }
            _context.Globalevents.Remove(ev);
            await _context.SaveChangesAsync();

            return ev;
        }

        public async Task<Globalevent> GetByEventIdAsync(int id)
        {
              return await _context.Globalevents.FindAsync(id);
            

        }

        public async Task<List<Globalevent>> GetByIdAsync()
        {
            return await _context.Globalevents.ToListAsync();
        }

        public async Task<Globalevent?> UpdateAsync(int id, CreateGlobalEventDto ev)
        {
            var eventModel = await _context.Globalevents.FirstOrDefaultAsync(x => x.EventId == id);
            if (eventModel == null)
            {
                return null;
            }
            eventModel.Title = ev.Title;
            eventModel.Description = ev.Description;
            eventModel.Date = ev.Date;
            await _context.SaveChangesAsync();
            return eventModel;
        }
    }
}

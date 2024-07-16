using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskSystemServer.Data;
using TaskSystemServer.Dtos.GlobalEvents;
using TaskSystemServer.Dtos.Registeredglobalevent;
using TaskSystemServer.Interfaces;
using TaskSystemServer.Mappers;
using TaskSystemServer.Models;

namespace TaskSystemServer.Repository
{
    public class RegisteredglobaleventRepository : IRegisteredglobaleventRepository
    {
        private readonly TasksystemContext _context;
        public RegisteredglobaleventRepository(TasksystemContext context)
        {
            _context = context;
        }

        public async Task<Registeredglobalevent> CreateAsync(Registeredglobalevent ev)
        {
            await _context.Registeredglobalevents.AddAsync(ev);
            await _context.SaveChangesAsync();

            //_context.Entry(ev).State = EntityState.Detached;
            // Reload the entity to reflect updates by the database trigger
            ev = await _context.Registeredglobalevents.Include(e=>e.Event).FirstOrDefaultAsync(x => x.EventId == ev.EventId && x.MemberId == ev.MemberId);
            
            
            return ev;
        }

        public async Task<Registeredglobalevent> DeleteAsync(int evId, int memberId)
        {
            var ev = _context.Registeredglobalevents.FirstOrDefault(x => x.EventId == evId && x.MemberId == memberId);
            if (ev == null)
            {
                return null;
            }
            _context.Registeredglobalevents.Remove(ev);
            await _context.SaveChangesAsync();

            return ev;
        }

        public async Task<List<Registeredglobalevent>> GetByIdAsync(int memberId)
        {
            return await _context.Registeredglobalevents.Include(e => e.Event).Where(e => e.MemberId == memberId).ToListAsync();
        }

        public async Task<Registeredglobalevent> GetByRegisteredglobaleventIdAsync(int evId,int memberId)
        {
            var registeredGlobalEvent= await _context.Registeredglobalevents.Include(e => e.Event).FirstOrDefaultAsync(x => x.EventId == evId && x.MemberId == memberId);

            return registeredGlobalEvent;
          

        }



        public async Task<Registeredglobalevent?> UpdateAsync(int evId,int memberId, UpdateRegisteredglobaleventDto ev)
        {
            var registeredeventModel = await _context.Registeredglobalevents.Include(e => e.Event).FirstOrDefaultAsync(x => x.EventId == evId && x.MemberId ==memberId );
            if (registeredeventModel == null)
            {
                return null;
            }
            registeredeventModel.RemindBeforeHours = ev.RemindBeforeHours;

            await _context.SaveChangesAsync();
            return registeredeventModel;
        }
    }
}

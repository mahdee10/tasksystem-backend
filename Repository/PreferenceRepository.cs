using Microsoft.EntityFrameworkCore;
using TaskSystemServer.Data;
using TaskSystemServer.Dtos.Preferences;
using TaskSystemServer.Interfaces;
using TaskSystemServer.Models;

namespace TaskSystemServer.Repository
{
    public class PreferenceRepository : IPrefernceRepository
    {
        private readonly TasksystemContext _context;

        public PreferenceRepository(TasksystemContext context)
        {
            _context = context;
        }

        public async Task<Memberprefernce> CreateAsync(Memberprefernce preference)
        {
          
                await _context.Memberprefernces.AddAsync(preference);
                await _context.SaveChangesAsync();
                return preference;
            
        }

        public async Task<Memberprefernce?> GetByIdAsync(int id)
        {
            var preModel = await _context.Memberprefernces.FirstOrDefaultAsync(x => x.MemberId == id);

            return preModel;
        }

        public async Task<Memberprefernce> UpdateAsync(int id, PreferenceDto preference)
        {
            var preModel = await _context.Memberprefernces.FirstOrDefaultAsync(x => x.MemberId == id);
            if (preModel == null)
            {
                return null;
            }
            preModel.Layout = preference.Layout;
            preModel.Theme = preference.Theme;

            await _context.SaveChangesAsync();
            return preModel;
        }
    }
}

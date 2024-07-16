using Microsoft.EntityFrameworkCore;
using TaskSystemServer.Data;
using TaskSystemServer.Interfaces;
using TaskSystemServer.Models;

namespace TaskSystemServer.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly TasksystemContext _context;

        public ProfileRepository(TasksystemContext context) { 
            _context = context;
        }
        public async Task<Memberprofile> CreateAsync(Memberprofile profile)
        {
            await _context.Memberprofiles.AddAsync(profile);
            await _context.SaveChangesAsync();

            return profile;
        }

        public async Task<Memberprofile> DeleteAsync(int id)
        {
            var profile = _context.Memberprofiles.FirstOrDefault(p => p.MemberId == id);
            if (profile == null)
            {
                return null;
            }
            _context.Memberprofiles.Remove(profile);

            await _context.SaveChangesAsync();

            return profile;
        }

        public async Task<Memberprofile?> GetByIdAsync(int id)
        {
            return await _context.Memberprofiles.FindAsync(id);
        }
    }
}

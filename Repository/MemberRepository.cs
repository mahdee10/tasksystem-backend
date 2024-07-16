using Microsoft.EntityFrameworkCore;
using TaskSystemServer.Data;
using TaskSystemServer.Interfaces;
using TaskSystemServer.Models;

namespace TaskSystemServer.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly TasksystemContext _context;
        public MemberRepository(TasksystemContext tasksystemContext) { 
            _context = tasksystemContext;
        }

        public async Task<Member> CreateAsync(Member member)
        {
            await _context.Members.AddAsync(member);
            await _context.SaveChangesAsync();

            return member;
        }

        Task<Member> IMemberRepository.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Member?>> GetAllAsync()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task<Member?> GetByIdAsync(int id)
        {
            var member = await _context.Members.Include(m=>m.Memberprefernce).Include(m=>m.Events).Include(m => m.Tasks).Include(m => m.Registeredglobalevents).FirstOrDefaultAsync(m => m.MemberId == id);
            
            if (member != null)
            {
                await _context.Entry(member)
                    .Collection(m => m.Registeredglobalevents)
                    .Query()
                    .Include(r => r.Event)
                    .LoadAsync();
            }
            return member;
            //return await _context.Members.Include(m=>m.Memberprefernce).Include(m=>m.Events).Include(m => m.Tasks).Include(m => m.Registeredglobalevents).FirstOrDefaultAsync(m => m.MemberId == id);
        }

        public async Task<Member?> GetByUserIdAsync(string id)
        {
            return await _context.Members.FirstOrDefaultAsync(m => m.AppUserId == id);
        }

        //Task<Member> IMemberRepository.UpdateAsync(int id, Member member)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

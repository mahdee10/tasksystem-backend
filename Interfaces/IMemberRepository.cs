using TaskSystemServer.Models;

namespace TaskSystemServer.Interfaces
{
    public interface IMemberRepository
    {
        Task<List<Member?>> GetAllAsync();
        Task<Member?> GetByIdAsync(int id);
        Task<Member?> GetByUserIdAsync(string id);
        Task<Member> CreateAsync(Member member);
        //Task<Member> UpdateAsync(int id, Member member);
        Task<Member> DeleteAsync(int id);
    }
}

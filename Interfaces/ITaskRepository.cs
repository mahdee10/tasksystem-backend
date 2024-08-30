
using TaskSystemServer.Dtos.Task;
using TaskSystemServer.Helpers;
using TaskSystemServer.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TaskSystemServer.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskSystemServer.Models.Task?>> GetByIdAsync(int id, QueryObject query);
        Task<TaskSystemServer.Models.Task> GetByTaskIdAsync(int id);
        Task<TaskSystemServer.Models.Task?> UpdateAsync(int id, UpdateTaskDto task);
        Task<TaskSystemServer.Models.Task> DeleteAsync(int id);
        Task<TaskSystemServer.Models.Task> CreateAsync(TaskSystemServer.Models.Task task);
    }
}

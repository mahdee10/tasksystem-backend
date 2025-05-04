
using TaskSystemServer.Dtos.Task;

namespace TaskSystemServer.Mappers
{
    public static class TaskMappers
    {
        public static TaskDto ToTaskDto(this Models.Task task)
        {
            return new TaskDto
            {
                TaskId = task.TaskId,
                Title = task.Title,
                Description = task.Description,
                Date = task.Date,
                DueDate = task.DueDate,
                Duration = task.Duration,
                PriorityLevel = task.PriorityLevel,
                IsDone = task.IsDone,
                RemindBeforeHours = task.RemindBeforeHours,
                IsReminded = task.IsReminded,
                
            };

        }

        public static Models.Task ToTaskFromCreate(this CreateTaskDto task, int id)
        {

            return new Models.Task
            {
                MemberId = id,
                Title = task.Title,
                Description = task.Description,
                Date = DateTime.UtcNow,
                DueDate = task.DueDate?.ToUniversalTime(),
                PriorityLevel = task.PriorityLevel,
                //IsDone = task.IsDone,
                RemindBeforeHours = task.RemindBeforeHours
            };

        }

    }
}

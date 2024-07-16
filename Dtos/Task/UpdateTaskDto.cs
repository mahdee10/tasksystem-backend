namespace TaskSystemServer.Dtos.Task
{
    public class UpdateTaskDto
    {

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? DueDate { get; set; }

        public int? RemindBeforeHours { get; set; }

        public bool? IsDone { get; set; }


        public string? PriorityLevel { get; set; }
    }
}

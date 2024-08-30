namespace TaskSystemServer.Dtos.Task
{
    public class TaskDto
    {
        public int TaskId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? Date { get; set; }

        public DateTime? DueDate { get; set; }

        public int? RemindBeforeHours { get; set; }

        public bool? IsDone { get; set; }

        public TimeSpan? Duration { get; set; }

        public string? PriorityLevel { get; set; }

        public bool? IsReminded { get; set; }

    }
}

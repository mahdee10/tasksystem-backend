namespace TaskSystemServer.Dtos.Event
{
    public class UpdateEventDto
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? Date { get; set; }

        public int? RemindBeforeHours { get; set; }
    }
}

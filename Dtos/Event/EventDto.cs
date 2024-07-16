namespace TaskSystemServer.Dtos.Event
{
    public class EventDto
    {
        public int EventId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? Date { get; set; }

        public int? RemindBeforeHours { get; set; }

        //public virtual Member Member { get; set; } = null!;
    }
}

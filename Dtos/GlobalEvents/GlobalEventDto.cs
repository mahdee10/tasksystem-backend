namespace TaskSystemServer.Dtos.GlobalEvents
{
    public class GlobalEventDto
    {
        public int EventId { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? Date { get; set; }
    }
}

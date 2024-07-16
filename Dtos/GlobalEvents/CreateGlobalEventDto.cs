namespace TaskSystemServer.Dtos.GlobalEvents
{
    public class CreateGlobalEventDto
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? Date { get; set; }
    }
}

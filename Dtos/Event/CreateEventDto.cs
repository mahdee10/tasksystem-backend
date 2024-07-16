namespace TaskSystemServer.Dtos.Event
{
    public class CreateEventDto
    {
        //public int MemberId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? Date { get; set; }

        public int? RemindBeforeHours { get; set; }
    }
}

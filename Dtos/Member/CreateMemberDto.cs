namespace TaskSystemServer.Dtos.Member
{
    public class CreateMemberDto
    {
        public string? Name { get; set; }

        public DateOnly? Dob { get; set; }

        public string? Timezone { get; set; }
        public string? AppUserId { get; set; }
    }
}

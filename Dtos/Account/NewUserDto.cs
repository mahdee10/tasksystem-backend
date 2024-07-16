namespace TaskSystemServer.Dtos.Account
{
    public class NewUserDto
    {
        public string? Username { get; set; }
        public string? EmailAddress { get; set; }
        public int MemberId { get; set; }
        public string? Token { get; set; }

    }
}

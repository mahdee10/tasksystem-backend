using System.ComponentModel.DataAnnotations;

namespace TaskSystemServer.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        public string? EmailAddress { get; set; }
        [Required]
        public string? Password { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public DateOnly? Dob { get; set; }
        [Required]
        public string? Timezone { get; set; }

    }
}

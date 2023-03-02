using System.ComponentModel.DataAnnotations;

namespace ChatApi.Models
{
    public class SignUpData
    {
        public required string UserName { get; set; }

        public required string Password { get; set; }

        public required string ConfirmPassword { get; set; }
    }
}

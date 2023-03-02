using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

namespace ChatApi.DTOs
{
    [PrimaryKey(nameof(ChatId), nameof(UserId))]
    public class ChatMemberDTO
    {
        public Guid ChatId { get; set; }

        public virtual ChatDTO? Chat { get; set; }

        public Guid UserId { get; set; }

        public virtual UserDTO? User { get; set; }

        public bool IsAdmin { get; set; }
    }
}

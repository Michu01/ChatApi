using Microsoft.EntityFrameworkCore;

namespace ChatApi.DTOs
{
    [PrimaryKey(nameof(MessageId), nameof(UserId))]
    public class MessageViewDTO
    {
        public Guid MessageId { get; set; }

        public virtual MessageDTO? Message { get; set; }

        public Guid UserId { get; set; }

        public virtual UserDTO? User { get; set; }

        public DateTime SeenAt { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace ChatApi.DTOs
{
    [PrimaryKey(nameof(SenderId), nameof(ReceiverId))]
    public class FriendshipRequestDTO
    {
        public Guid SenderId { get; set; }

        public virtual UserDTO? Sender { get; set; }

        public Guid ReceiverId { get; set; }

        public virtual UserDTO? Receiver { get; set; }
    }
}

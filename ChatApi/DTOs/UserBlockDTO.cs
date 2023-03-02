using Microsoft.EntityFrameworkCore;

namespace ChatApi.DTOs
{
    [PrimaryKey(nameof(BlockingUserId), nameof(BlockedUserId))]
    public class UserBlockDTO
    {
        public Guid BlockingUserId { get; set; }

        public virtual UserDTO? BlockingUser { get; set; }

        public Guid BlockedUserId { get; set; }

        public virtual UserDTO? BlockedUser { get; set; }
    }
}

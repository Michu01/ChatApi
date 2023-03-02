using Microsoft.AspNetCore.Identity;

namespace ChatApi.DTOs
{
    public class UserDTO : IdentityUser<Guid>
    {
        public virtual ICollection<FriendshipRequestDTO> FriendshipRequests { get; set; } = new List<FriendshipRequestDTO>();

        public virtual ICollection<FriendshipDTO> Friendships { get; set; } = new List<FriendshipDTO>();

        public virtual ICollection<ChatMemberDTO> Chats { get; set; } = new List<ChatMemberDTO>();

        public virtual ICollection<MessageDTO> Messages { get; set; } = new List<MessageDTO>();

        public virtual ICollection<UserBlockDTO> UserBlocks { get; set; } = new List<UserBlockDTO>();

        public virtual ICollection<MessageViewDTO> MessageViews { get; set; } = new List<MessageViewDTO>();
    }
}

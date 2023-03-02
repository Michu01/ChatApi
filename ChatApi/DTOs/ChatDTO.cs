using System.ComponentModel.DataAnnotations;

namespace ChatApi.DTOs
{
    public class ChatDTO
    {
        public Guid Id { get; set; }

        public bool IsGroup { get; set; }

        public virtual ICollection<ChatMemberDTO> Members { get; set; } = new List<ChatMemberDTO>();

        public virtual ICollection<MessageDTO> Messages { get; set; } = new List<MessageDTO>();
    }
}

using System.ComponentModel.DataAnnotations;

using ChatApi.Enums;

namespace ChatApi.DTOs
{
    public class MessageDTO
    {
        public Guid Id { get; set; }

        public DateTime SentAt { get; set; }

        [MaxLength(65536)]
        public string Content { get; set; } = "";

        public MessageContentType ContentType { get; set; }

        public Guid ChatId { get; set; }

        public virtual ChatDTO? Chat { get; set; }

        public Guid SenderId { get; set; }

        public virtual UserDTO? Sender { get; set; }

        public virtual ICollection<MessageViewDTO> MessageViews { get; set; } = new List<MessageViewDTO>();
    }
}

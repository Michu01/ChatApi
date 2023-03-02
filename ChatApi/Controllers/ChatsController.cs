using ChatApi.DTOs;
using ChatApi.Repositories;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;

namespace ChatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly ChatMemberRepository chatMemberRepository;

        private readonly MessageRepository messageRepository;

        public ChatsController(ChatMemberRepository chatMemberRepository, MessageRepository messageRepository)
        {
            this.chatMemberRepository = chatMemberRepository;
            this.messageRepository = messageRepository;
        }

        [HttpGet("{chatId}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<MessageDTO>>> GetMessages(Guid chatId, Guid? minId = null, int count = 30)
        {
            if (!Guid.TryParse(User.GetNameIdentifierId() ?? "", out Guid userId) ||
                !await chatMemberRepository.IsChatMember(chatId, userId))
            {
                return BadRequest();
            }

            return messageRepository.Get(chatId, minId, count).ToList();
        }
    }
}

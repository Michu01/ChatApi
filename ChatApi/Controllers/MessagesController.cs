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
    public class MessagesController : ControllerBase
    {
        private readonly ChatMemberRepository chatMemberRepository;

        private readonly MessageRepository messageRepository;

        public MessagesController(ChatMemberRepository chatMemberRepository, MessageRepository messageRepository)
        {
            this.chatMemberRepository = chatMemberRepository;
            this.messageRepository = messageRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<MessageDTO>> Get(Guid id)
        {
            if (!Guid.TryParse(User.GetNameIdentifierId() ?? "", out Guid userId) ||
                await messageRepository.Get(id) is not MessageDTO message ||
                !await chatMemberRepository.IsChatMember(message.ChatId, userId))
            {
                return BadRequest();
            }

            return message;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(MessageDTO message)
        {
            if (!Guid.TryParse(User.GetNameIdentifierId() ?? "", out Guid userId) ||
                message.SenderId != userId ||
                !await chatMemberRepository.IsChatMember(message.ChatId, message.SenderId))
            {
                return BadRequest();
            }

            await messageRepository.Add(message);

            return CreatedAtAction(nameof(Get), new { message.Id }, message);
        }
    }
}

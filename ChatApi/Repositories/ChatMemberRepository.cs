using ChatApi.DbContexts;
using ChatApi.DTOs;

using Microsoft.EntityFrameworkCore;

namespace ChatApi.Repositories
{
    public class ChatMemberRepository
    {
        private readonly ChatDbContext dbContext;

        private DbSet<ChatMemberDTO> ChatMembers => dbContext.ChatMembers;

        public ChatMemberRepository(ChatDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> IsChatMember(Guid chatId, Guid userId)
        {
            return await ChatMembers.FindAsync(chatId, userId) is not null;
        }
    }
}

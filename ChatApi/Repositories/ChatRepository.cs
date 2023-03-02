using ChatApi.DbContexts;
using ChatApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Repositories
{
    public class ChatRepository
    {
        private readonly ChatDbContext dbContext;

        private DbSet<ChatDTO> Chats => dbContext.Chats;

        public ChatRepository(ChatDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task Add(ChatDTO chatDTO)
        {
            Chats.Add(chatDTO);
            return dbContext.SaveChangesAsync();
        }
    }
}

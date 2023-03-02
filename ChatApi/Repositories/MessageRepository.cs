using ChatApi.DbContexts;
using ChatApi.DTOs;

using Microsoft.EntityFrameworkCore;

namespace ChatApi.Repositories
{
    public class MessageRepository
    {
        private readonly ChatDbContext dbContext;

        private DbSet<MessageDTO> Messages => dbContext.Messages;

        public MessageRepository(ChatDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ValueTask<MessageDTO?> Get(Guid id)
        {
            return Messages.FindAsync(id);
        }

        public IQueryable<MessageDTO> Get(Guid chatId, Guid? minId, int count) 
        {
            return Messages.Where(m => m.ChatId == chatId).Where(m => m.Id > minId).Take(count);
        }

        public Task Add(MessageDTO message)
        {
            Messages.Add(message);
            return dbContext.SaveChangesAsync();
        }
    }
}

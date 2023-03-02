using ChatApi.DTOs;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.DbContexts
{
    public class ChatDbContext : IdentityDbContext<UserDTO, IdentityRole<Guid>, Guid>
    {
        public virtual DbSet<MessageDTO> Messages { get; set; }

        public virtual DbSet<ChatDTO> Chats { get; set; }

        public virtual DbSet<ChatMemberDTO> ChatMembers { get; set; }

        public virtual DbSet<FriendshipDTO> Friendships { get; set; }

        public virtual DbSet<FriendshipRequestDTO> FriendshipRequests { get; set; }

        public virtual DbSet<MessageViewDTO> MessageViews { get; set; }

        public virtual DbSet<UserBlockDTO> UserBlocks { get; set; }

        public ChatDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<FriendshipDTO>()
                .HasOne(f => f.First)
                .WithMany(f => f.Friendships)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<FriendshipRequestDTO>()
               .HasOne(f => f.Receiver)
               .WithMany(f => f.FriendshipRequests)
               .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserBlockDTO>()
               .HasOne(f => f.BlockedUser)
               .WithMany(f => f.UserBlocks)
               .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<MessageViewDTO>()
                .HasOne(m => m.Message)
                .WithMany(m => m.MessageViews)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

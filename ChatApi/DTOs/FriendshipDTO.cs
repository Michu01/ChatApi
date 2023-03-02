using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

namespace ChatApi.DTOs
{
    [PrimaryKey(nameof(FirstId), nameof(SecondId))]
    public class FriendshipDTO
    {
        public Guid FirstId { get; set; }

        public virtual UserDTO? First { get; set; }

        public Guid SecondId { get; set; }

        public virtual UserDTO? Second { get; set; }
    }
}

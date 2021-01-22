using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L2P_RPG_GOI.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public ulong DiscordUserId { get; set; }
        public string Username { get; set; }
        public string Discriminator { get; set; }
    }
}

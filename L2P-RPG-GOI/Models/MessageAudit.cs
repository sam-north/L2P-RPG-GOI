using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L2P_RPG_GOI.Models
{
    [Table("MessageAudit")]
    public class MessageAudit
    {
        [Key]
        public long Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public DateTimeOffset Time { get; set; }
    }
}

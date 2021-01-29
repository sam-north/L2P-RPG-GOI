using L2P_RPG_GOI.Models;
using Microsoft.EntityFrameworkCore;

namespace L2P_RPG_GOI.DataAccess
{
    public class EntityContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<MessageAudit> MessageAudits { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                       .Entity<Attack>(builder =>
                       {
                           builder.HasNoKey();
                       });
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.\;Database=L2P_RPG;Integrated Security=True");
        }
    }
}

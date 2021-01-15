using Microsoft.EntityFrameworkCore;

namespace L2P_RPG_GOI.DataAccess
{
    public class EntityContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Class> Classes { get; set; }

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
                @"Server=.\SQL2019;Database=L2P_RPG;Integrated Security=True");
        }
    }
}

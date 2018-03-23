using System.Data.Entity;
using Soccer.Data.Entities;

namespace Soccer.Data
{
    public class SoccerDbContext : DbContext
    {
        static SoccerDbContext()
        {
            Database.SetInitializer<DbContext>(null);
        }

        public SoccerDbContext(string connectionString)
            : base(connectionString)
        {

        }

        public DbSet<PlayerEntity> Players { get; set; }
        public DbSet<TeamEntity> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerEntity>()
                .HasRequired(x => x.TeamEntity)
                .WithMany(x => x.Players)
                .HasForeignKey(x => x.TeamEntityId);
        }
    }
}
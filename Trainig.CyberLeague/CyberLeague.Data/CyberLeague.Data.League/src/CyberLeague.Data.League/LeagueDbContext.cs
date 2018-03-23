using System.Data.Entity;
using CyberLeague.Data.League.Entities;
using CyberLeague.Data.League.EntitiesConfiguration;

namespace CyberLeague.Data.League
{
    public class LeagueDbContext : DbContext
    {
        static LeagueDbContext()
        {
            Database.SetInitializer<LeagueDbContext>(null);
        }

        public LeagueDbContext(string connectionString)
            : base(connectionString)
        {

        }

        public DbSet<TeamEntity> Teams { get; set; }
        public DbSet<PositionEntity> Positions { get; set; }
        public DbSet<PlayerEntity> Players { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TeamEntityConfiguration());
            modelBuilder.Configurations.Add(new PlayerEntityConfiguration());
            modelBuilder.Configurations.Add(new PositionEntityConfiguration());
        }
    }
}
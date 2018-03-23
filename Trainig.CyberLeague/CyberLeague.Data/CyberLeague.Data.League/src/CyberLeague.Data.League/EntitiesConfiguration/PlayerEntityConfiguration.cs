using System.Data.Entity.ModelConfiguration;
using CyberLeague.Data.League.Entities;

namespace CyberLeague.Data.League.EntitiesConfiguration
{
    public class PlayerEntityConfiguration : EntityTypeConfiguration<PlayerEntity>
    {
        public PlayerEntityConfiguration()
        {
            ToTable("Players", schemaName: "League");

            HasRequired(x => x.TeamEntity)
                .WithMany(x => x.Players)
                .HasForeignKey(x => x.TeamEntityId);

            Property(x => x.Name).HasMaxLength(50)
                .IsRequired();

            HasRequired(x => x.PositionEntity)
                .WithMany(x => x.Players)
                .HasForeignKey(x => x.PositionEntityId);
        }
    }
}
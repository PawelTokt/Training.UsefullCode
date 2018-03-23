using System.Data.Entity.ModelConfiguration;
using CyberLeague.Data.League.Entities;

namespace CyberLeague.Data.League.EntitiesConfiguration
{
    public class TeamEntityConfiguration : EntityTypeConfiguration<TeamEntity>
    {
        public TeamEntityConfiguration()
        {
            ToTable("Teams", schemaName: "League");
        }
    }
}
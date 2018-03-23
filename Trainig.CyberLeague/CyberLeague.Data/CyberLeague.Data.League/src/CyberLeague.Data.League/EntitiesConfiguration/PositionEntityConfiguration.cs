using System.Data.Entity.ModelConfiguration;
using CyberLeague.Data.League.Entities;

namespace CyberLeague.Data.League.EntitiesConfiguration
{
    public class PositionEntityConfiguration : EntityTypeConfiguration<PositionEntity>
    {
        public PositionEntityConfiguration()
        {
            ToTable("Positions", schemaName: "League");
        }
    }
}
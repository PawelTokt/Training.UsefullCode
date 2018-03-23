using System.Collections.Generic;

namespace CyberLeague.Data.League.Entities
{
    public class TeamEntity : Entity
    {
        public string Name { get; set; }
        public string Region { get; set; }

        public virtual ICollection<PlayerEntity> Players { get; set; }
    }
}
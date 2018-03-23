using System.Collections.Generic;

namespace CyberLeague.Data.League.Entities
{
    public class PositionEntity : Entity
    {
        public string Name { get; set; }
        public int KillСoefficient { get; set; }
        public int AssistlСoefficient { get; set; }
        public int DeathlСoefficient { get; set; }

        public virtual ICollection<PlayerEntity> Players { get; set; }
    }
}
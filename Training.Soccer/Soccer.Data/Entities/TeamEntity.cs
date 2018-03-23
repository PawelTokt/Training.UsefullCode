using System.Collections.Generic;

namespace Soccer.Data.Entities
{
    public class TeamEntity : Entity
    {
        //public TeamEntity()
        //{
        //    // ReSharper disable once VirtualMemberCallInConstructor
        //    Players = new List<PlayerEntity>();
        //}

        public virtual string Name { get; set; }
        public virtual string Coach { get; set; }
        public virtual ICollection<PlayerEntity> Players { get; set; }
    }
}
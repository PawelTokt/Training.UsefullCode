using Soccer.Data.Interfaces;

namespace Soccer.Data.Entities
{
    public class Entity : IEntity
    {
        public virtual int Id { get; set; }
    }
}
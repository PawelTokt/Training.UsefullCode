namespace Soccer.Data.Entities
{
    public class PlayerEntity : Entity
    {
        public virtual string Name { get; set; }
        //public virtual int Age { get; set; }
        public virtual string Position { get; set; }
        public int TeamEntityId { get; set; }
        public virtual TeamEntity TeamEntity { get; set; }
    }
}
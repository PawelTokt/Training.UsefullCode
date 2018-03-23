namespace CyberLeague.Data.League.Entities
{
    public class PlayerEntity : Entity
    {
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Surname { get; set; }

        public int? PositionEntityId { get; set; }
        public PositionEntity PositionEntity { get; set; }

        public int? TeamEntityId { get; set; }
        public TeamEntity TeamEntity { get; set; }
    }
}
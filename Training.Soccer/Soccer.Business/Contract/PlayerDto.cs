namespace Soccer.Business.Contract
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public  string Position { get; set; }
        public  int TeamEmtityId { get; set; }
        public string TeamName { get; set; }
    }
}
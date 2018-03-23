namespace Soccer.Business.Contract
{
    public class TeamDto
    {
        public int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Coach { get; set; }
    }
}
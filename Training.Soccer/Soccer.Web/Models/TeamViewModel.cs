namespace Soccer.Web.Models
{
    public class TeamViewModel
    {
        public int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Coach { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Training.Data.EntityFramework
{
    public class Entity : IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
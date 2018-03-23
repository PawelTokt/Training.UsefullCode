using Microsoft.EntityFrameworkCore;

namespace MobileStore.Models
{
    public class MobileContext : DbContext
    {
        public MobileContext(DbContextOptions<MobileContext> options)
            : base(options)
        {

        }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
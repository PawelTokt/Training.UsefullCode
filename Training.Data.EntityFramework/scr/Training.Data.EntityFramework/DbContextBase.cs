using System.Data.Entity;

namespace Training.Data.EntityFramework
{
    public class DbContextBase<TContext> : DbContext
        where TContext : DbContext
    {
        static DbContextBase()
        {
            Database.SetInitializer<TContext>(null);
        }

        public DbContextBase(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
    }
}
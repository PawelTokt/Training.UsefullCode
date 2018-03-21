using Microsoft.EntityFrameworkCore;

namespace Migrations.Context
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }
    }
}
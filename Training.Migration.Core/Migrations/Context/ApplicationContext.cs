using Data;
using Microsoft.EntityFrameworkCore;

namespace Migrations.Context
{
    public class ApplicationContext : ApplicationDbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }
    }
}
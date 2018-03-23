using CyberLeague.Data.League;

namespace CyberLeague.Migrations
{
    public class LeagueContext : LeagueDbContext
    {
        public LeagueContext() 
            : base("DefaultConnection")
        {

        }
    }
}
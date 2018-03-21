using Microsoft.AspNetCore.Identity;

namespace Identity.Models
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}
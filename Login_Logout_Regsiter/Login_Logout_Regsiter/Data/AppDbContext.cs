using Login_Logout_Regsiter.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Login_Logout_Regsiter.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}

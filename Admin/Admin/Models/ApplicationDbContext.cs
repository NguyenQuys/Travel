using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Admin.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base (options) { }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}

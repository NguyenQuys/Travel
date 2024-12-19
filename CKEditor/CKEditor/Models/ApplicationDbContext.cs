using Microsoft.EntityFrameworkCore;

namespace CKEditor.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>
        options) : base(options)
        {
        }
        public DbSet<Content> Content { get; set; }
    }
}

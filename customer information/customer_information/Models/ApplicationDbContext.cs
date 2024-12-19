using Microsoft.EntityFrameworkCore;
using customer_information.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
namespace customer_information.Models
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}

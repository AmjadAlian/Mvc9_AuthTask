using Microsoft.EntityFrameworkCore;
using Mvc9_AuthTask.Models;

namespace Mvc9_AuthTask.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}

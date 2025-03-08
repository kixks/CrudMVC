using Microsoft.EntityFrameworkCore;

namespace CrudNonApiMVC.Data
{
    public class ContextInfo : DbContext
    {
        public ContextInfo(DbContextOptions<ContextInfo> options) : base(options)
        {
        }
        public DbSet<Models.Employee> Employees { get; set; }
    }
}

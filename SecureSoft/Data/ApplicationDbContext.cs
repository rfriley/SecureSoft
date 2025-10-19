using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Assignment4.Models;

namespace SecureSoft.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Assignment4.Models.Employee> Employee { get; set; } = default!;
        public DbSet<Assignment4.Models.Order> Order { get; set; } = default!;
    }
}

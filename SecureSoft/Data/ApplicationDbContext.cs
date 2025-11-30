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
        public virtual DbSet<Employee> Employee { get; set; }

        public virtual DbSet<Order> Order { get; set; }

        public virtual DbSet<Shipper> Shippers { get; set; }
    }
}

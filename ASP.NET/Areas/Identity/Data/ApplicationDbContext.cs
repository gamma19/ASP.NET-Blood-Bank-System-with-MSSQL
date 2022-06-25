using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Final2.Models;

namespace Final2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Final2.Models.Donor>? Donor { get; set; }
        public DbSet<Final2.Models.Seeker>? Seeker { get; set; }
        public DbSet<Final2.Models.Hospital>? Hospital { get; set; }
        public DbSet<Final2.Models.BloodBank>? BloodBank { get; set; }
        public DbSet<Final2.Models.Blood>? Blood { get; set; }
    }
}
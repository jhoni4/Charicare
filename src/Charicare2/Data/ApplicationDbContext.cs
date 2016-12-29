using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Charicare2.Models;

namespace Charicare2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>() //Use your application user class here
                .ToTable("AspNetUsers");

            builder.Entity<Donate>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");
        }
        public DbSet<ApplicationUser> User { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<DonateType> DonateType { get; set; }
        public DbSet<Donate> Donate { get; set; }

        
    }
}

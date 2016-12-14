﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Charicare2.Models;

namespace Charicare2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<User> User { get; set; }
        //public DbSet<ClothesDonate> ClothesDonate { get; set; }
        //public DbSet<MoneyDonate> MoneyDonate { get; set; }
        //public DbSet<MedicalDonate> MedicalDonate { get; set; }
        //public DbSet<GoodsDonate> GoodsDonate { get; set; }
        public DbSet<DonateType> DonateType { get; set; }
        public DbSet<Donate> Donate { get; set; }

    }
}

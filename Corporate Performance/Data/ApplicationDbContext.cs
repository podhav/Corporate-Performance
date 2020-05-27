using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Corporate_Performance.Models;

namespace Corporate_Performance.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Programme>Programme { get; set;}
        public DbSet<KPA>KPA { get; set; }
        public DbSet<KPI>KPI { get; set; }
        public DbSet<Period>Period { get; set; }
        public DbSet<Fiscal>Fiscal { get; set; }
        public DbSet<Performance>Performance { get; set; }

    }
}

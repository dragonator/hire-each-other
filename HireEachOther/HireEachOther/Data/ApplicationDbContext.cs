using System;
using System.Collections.Generic;
using System.Text;
using HireEachOther.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HireEachOther.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ad> Ads { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // User
            builder.Entity<User>()
                .ToTable("Users");


            // Ad
            builder.Entity<Ad>()
                .HasKey(a => a.Id);

            builder.Entity<Ad>()
                .ToTable("Ads");


        }
    }
}

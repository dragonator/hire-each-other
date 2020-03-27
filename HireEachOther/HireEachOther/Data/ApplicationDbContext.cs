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

            // Users
            builder.Entity<User>()
                .ToTable("Users");
            // Owned 
            builder.Entity<User>()
                .HasMany(u => u.OwnedAds)
                .WithOne(a => a.Owner)
                .HasForeignKey("UserId");
            // Applications
            builder.Entity<User>()
                .HasMany(u => u.Applications)
                .WithOne(ap => ap.User);


            // Ads
            builder.Entity<Ad>()
                .HasKey(a => a.Id);
            // Owner
            builder.Entity<Ad>()
                .HasOne(a => a.Owner)
                .WithMany(o => o.OwnedAds)
                .HasForeignKey("UserId");
                
            // Applicants
            builder.Entity<Ad>()
                .HasMany(a => a.Applicants)
                .WithOne(ap => ap.Ad);
            // table name 
            builder.Entity<Ad>()
                .ToTable("Ads");


            builder.Entity<Applicants>()
                   .HasKey(a => new { a.UserId, a.AdId });
       
        }
    }
}

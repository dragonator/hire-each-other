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
        public DbSet<UserComment> UserComments { get; set; }
        public DbSet<AdComment> AdComments { get; set; }

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
            // Comments targeted user
            builder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.Target)
                .HasForeignKey("TargetId");


            // UserComments made by User
            builder.Entity<UserComment>()
                .HasOne(u => u.Owner)
                .WithMany()
                .HasForeignKey("UserId");

            // AdComments made by User
            builder.Entity<AdComment>()
                .HasOne(u => u.Owner)
                .WithMany()
                .HasForeignKey("UserId");

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
            // Table name Ads
            builder.Entity<Ad>()
                .ToTable("Ads");
            // Ad comments
            builder.Entity<Ad>()
                .HasMany(a => a.Comments)
                .WithOne(ac => ac.Target)
                .HasForeignKey("TargetId");


            builder.Entity<Applicants>()
                   .HasKey(a => new { a.UserId, a.AdId });
        }
    }
}

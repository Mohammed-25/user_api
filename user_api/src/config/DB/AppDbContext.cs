using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductAppAsync.src;
using ProductApplication.Models;



namespace ProductAppAsync.src.config.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.userId);
                entity.Property(e => e.userName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.adreess).HasMaxLength(200);

                entity.HasOne(Users => Users.Profile)
                .WithOne(Profile => Profile.User)
                .HasForeignKey<Profile>(Profile => Profile.UserId);
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasKey(e => e.ProfileId);
                entity.Property(e => e.ProfileName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.age).IsRequired();
                entity.Property(e => e.PohneNumber).IsRequired().HasMaxLength(10);

                entity.HasOne(Profile => Profile.User)
                .WithOne(Users => Users.Profile)
                .HasForeignKey<Profile>(Profile => Profile.UserId);

            });
        }
    }
}
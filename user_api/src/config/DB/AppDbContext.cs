using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductAppAsync.src;


namespace ProductAppAsync.src.config.DB
{
    public class AppDbContext : DbContext 
    {
        // public DbSet<User> Users { get; set; }

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
            });
    } 
    }
}
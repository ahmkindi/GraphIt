using GraphIt.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GarphIt.api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public DbSet<Node> Nodes { get; set; }
        public DbSet<Edge> Edges { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Edge>()
                .Property(e => e.Weight)
                .HasDefaultValue(1);
            modelBuilder.Entity<Edge>()
                .HasOne(e => e.HeadNode)
                .WithMany(n => n.EdgesStart)
                .HasForeignKey(e => e.HeadId);
            modelBuilder.Entity<Edge>()
                .HasOne(e => e.TailNode)
                .WithMany(n => n.EdgesEnd)
                .HasForeignKey(e => e.TailId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

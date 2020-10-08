using GraphIt.models;
using Microsoft.EntityFrameworkCore;
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
            base.OnModelCreating(modelBuilder);
            //Seed Nodes Table
            modelBuilder.Entity<Node>().HasData(new Node
            {
                NodeId = 1,
                NodeColor = "#000000",
                Label = "Hello",
                LabelColor = "#dd1122",
                Xaxis = 10.12,
                Yaxis = 11.11
            });
            modelBuilder.Entity<Node>().HasData(new Node
            {
                NodeId = 2,
                NodeColor = "#123456",
                Label = "Bye",
                LabelColor = "#aabbcc",
                Xaxis = 1.0,
                Yaxis = 13.44
            });
            //Seed Edges Table
            modelBuilder.Entity<Edge>().HasData(new Edge 
            { 
                EdgeId = 1,
                EdgeColor = "#000000",
                Label = "Hello",
                LabelColor = "#dd1122",
                Weight = 10.12,
                HeadId = 1,
                TailId = 2
            });
        }
    }
}

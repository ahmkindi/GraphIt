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
    }
}

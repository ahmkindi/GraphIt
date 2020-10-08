using GraphIt.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarphIt.api.Models
{
    public class EdgeRepository : IEdgeRepositry
    {
        private readonly AppDbContext appDbContext;

        public EdgeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Edge>> GetEdges()
        {
            return await appDbContext.Edges.ToListAsync();
        }

        public async Task<Edge> GetEdge(int edgeId)
        {
            return await appDbContext.Edges
                .FirstOrDefaultAsync(e => e.EdgeId == edgeId);
        }

        public async Task<Edge> AddEdge(Edge edge)
        {
            var result = await appDbContext.Edges.AddAsync(edge);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Edge> UpdateEdge(Edge edge)
        {
            var result = await appDbContext.Edges
                .FirstOrDefaultAsync(e => e.EdgeId == edge.EdgeId);

            if (result != null)
            {
                result.Label = edge.Label;
                result.LabelColor = edge.LabelColor;
                result.HeadId = edge.HeadId;
                result.TailId = edge.TailId;
                result.Weight = edge.Weight;
                result.EdgeColor = edge.EdgeColor;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
        public async Task<Edge> DeleteEdge(int edgeId)
        {
            var result = await appDbContext.Edges
                .FirstOrDefaultAsync(e => e.EdgeId == edgeId);
            if (result != null)
            {
                appDbContext.Edges.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}

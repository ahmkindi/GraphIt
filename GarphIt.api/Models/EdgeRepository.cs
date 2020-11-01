using GraphIt.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarphIt.api.Models
{
    public class EdgeRepository : IEdgeRepository
    {
        private readonly AppDbContext appDbContext;

        public EdgeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Edge>> GetEdges()
        {
            return await appDbContext.Edges
                .Include(e => e.HeadNode)
                .Include(e => e.TailNode)
                .ToListAsync();
        }

        public async Task<Edge> GetEdge(int edgeId)
        {
            return await appDbContext.Edges
                .Include(e => e.HeadNode)
                .Include(e => e.TailNode)
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
                result.HeadNodeId = edge.HeadNodeId;
                result.TailNodeId = edge.TailNodeId;
                result.Weight = edge.Weight;
                result.EdgeColor = edge.EdgeColor;
                result.Directed = edge.Directed;
                result.Curve = edge.Curve;

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

        public async Task<IEnumerable<Edge>> Search(int headId, int tailId, bool directed)
        {
            IQueryable<Edge> query = appDbContext.Edges;
            if (directed)
            {
                query = query.Where(e => (e.HeadNodeId == headId && e.TailNodeId == tailId) 
                || (e.HeadNodeId == tailId && e.TailNodeId == headId && e.Directed == false));
            }
            if (!directed)
            {
                query = query.Where(e => (e.HeadNodeId == headId && e.TailNodeId == tailId)
                || (e.HeadNodeId == tailId && e.TailNodeId == headId));
            }
            return await query.ToListAsync();
        }
    }
}

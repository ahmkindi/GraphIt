using GraphIt.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarphIt.api.Models
{
    public class NodeRepository : INodeRepository
    {
        private readonly AppDbContext appDbContext;

        public NodeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Node>> GetNodes()
        {
            return await appDbContext.Nodes.ToListAsync();
        }

        public async Task<Node> GetNode(int nodeId)
        {
            return await appDbContext.Nodes
                .FirstOrDefaultAsync(e => e.NodeId == nodeId);
        }

        public async Task<Node> AddNode(Node node)
        {
            var result = await appDbContext.Nodes.AddAsync(node);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Node> UpdateNode(Node node)
        {
            var result = await appDbContext.Nodes
                .FirstOrDefaultAsync(e => e.NodeId == node.NodeId);

            if (result != null)
            {
                result.Label = node.Label;
                result.LabelColor = node.LabelColor;
                result.Xaxis = node.Xaxis;
                result.Yaxis = node.Yaxis;
                result.NodeColor = node.NodeColor;
                result.Radius = node.Radius;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Node> DeleteNode(int nodeId)
        {
            var result = await appDbContext.Nodes
                .FirstOrDefaultAsync(e => e.NodeId == nodeId);
            if (result != null)
            {
                appDbContext.Nodes.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}

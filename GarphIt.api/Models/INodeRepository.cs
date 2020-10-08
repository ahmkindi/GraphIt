using GraphIt.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarphIt.api.Models
{
    public interface INodeRepository
    {
        Task<IEnumerable<Node>> GetNodes();
        Task<Node> GetNode(int nodeId);
        Task<Node> AddNode(Node node);
        Task<Node> UpdateNode(Node node);
        Task<Node> DeleteNode(int nodeId);
    }
}

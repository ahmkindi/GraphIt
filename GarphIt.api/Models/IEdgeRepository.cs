using GraphIt.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarphIt.api.Models
{
    public interface IEdgeRepository
    {
        Task<IEnumerable<Edge>> GetEdges();
        Task<Edge> GetEdge(int edgeId);
        Task<Edge> AddEdge(Edge edge);
        Task<Edge> UpdateEdge(Edge edge);
        Task<Edge> DeleteEdge(int edgeId);
    }
}

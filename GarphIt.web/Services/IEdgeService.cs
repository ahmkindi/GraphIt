using GraphIt.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Services
{
    public interface IEdgeService
    {
        Task<IEnumerable<Edge>> GetEdges();
        Task<Edge> GetEdge(int id);
        Task<Edge> UpdateEdge(Edge updatedEdge);
        Task<Edge> AddEdge(Edge newEdge);
        Task DeleteEdge(int id);
    }
}

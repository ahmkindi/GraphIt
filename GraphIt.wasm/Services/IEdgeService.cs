using GraphIt.wasm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.wasm.Services
{
    public interface IEdgeService
    {
        Edge AddEdge(IList<Edge> edges, DefaultOptions d, Node head, Node tail, double weight);
        Edge AddEdge(IList<Edge> edges, DefaultOptions d, Node head, Node tail);
        Edge AddEdge(IList<Edge> edges, Edge e);
        Edge AddEdge(Graph graph, Edge e, int nextNodeId);
        void DeleteEdges(List<Edge> edges, IList<Edge> edgesToDel);
        void UpdateMultiGraph(Graph graph);
        IEnumerable<Edge> MultiGraphEdges(IEnumerable<Edge> edges, Node head, Node tail, bool directed);
        int NextId(IList<Edge> edges);
    }
}

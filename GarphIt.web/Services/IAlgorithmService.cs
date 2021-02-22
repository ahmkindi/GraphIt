using GraphIt.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Services
{
    public interface IAlgorithmService
    {
        void RunAlgorithm(DefaultOptions d, DefaultOptions a, StartAlgorithm startAlgorithm, IList<Node> nodes, ref IList<AlgorithmNode> algorithmNodes, IList<Edge> edges, ref IList<Edge> algorithmEdges);
        void Kruskal();
        void BFS();
        void DFS();
        void Dijkstra();
        void DijkstraPath();
        void Degree();
        void DegreeCentrality(string pref);
        void FordFulkerson();
        void Articulation();
    }
}

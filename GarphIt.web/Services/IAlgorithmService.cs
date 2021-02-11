using GraphIt.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Services
{
    public interface IAlgorithmService
    {
        void RunAlgorithm(DefaultOptions d, StartAlgorithm startAlgorithm, IList<Node> nodes, ref IList<AlgorithmNode> algorithmNodes, IList<Edge> edges, ref IList<Edge> algorithmEdges);
        void Kruskal(StartAlgorithm startAlgorithm, IList<Node> nodes, ref IList<AlgorithmNode> algorithmNodes, IList<Edge> edges, ref IList<Edge> algorithmEdges);
        void BFS(DefaultOptions d, StartAlgorithm startAlgorithm, IList<Node> nodes, ref IList<AlgorithmNode> algorithmNodes, ref IList<Edge> algorithmEdges);
        void DFS(DefaultOptions d, StartAlgorithm startAlgorithm, IList<Node> nodes, ref IList<AlgorithmNode> algorithmNodes, ref IList<Edge> algorithmEdges);
        void Dijkstra(DefaultOptions d, StartAlgorithm startAlgorithm, IList<Node> nodes, ref IList<AlgorithmNode> algorithmNodes, ref IList<Edge> algorithmEdges);
    }
}
